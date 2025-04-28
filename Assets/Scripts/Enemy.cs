using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField, Header("移動速度")]
    private float _moveSpeed;
    [SerializeField, Header("攻撃力")]
    private int _attackPower;

    private Rigidbody2D _rigid;
    private Vector2 _moveDirection;
    private bool _bFloor;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rigid = GetComponent<Rigidbody2D>();
        _moveDirection = Vector2.left;
    }

    // Update is called once per frame
    void Update()
    {
        _Move();
        _ChangeMoveDirection();
        _LookMoveDirection();
        if (transform.position.y < -10)
        {
            Destroy(gameObject);
        }

    }

    private void _Move()
    {
        if (_bFloor) return;
        _rigid.linearVelocity = new Vector2(_moveDirection.x * _moveSpeed, _rigid.linearVelocity.y);
    }

    private void _ChangeMoveDirection()
    {
        Vector2 halfSize = transform.lossyScale / 2.0f;
        int layerMask = LayerMask.GetMask("Floor");
        RaycastHit2D ray = Physics2D.Raycast(transform.position, -transform.right, halfSize.x + 0.1f, layerMask);
        if (ray.transform == null) return;
        if (ray.transform.tag == "Floor")
        {
            _moveDirection = -_moveDirection;
        }
    }

    private void _LookMoveDirection()
    {
        if (_moveDirection.x < 0.0f)
        {
            transform.eulerAngles = Vector3.zero;
        }
        else if (_moveDirection.x > 0.0f)
        {
            transform.eulerAngles = new Vector3(0.0f, 180.0f, 0.0f);
        }
    }

    private void _HitFloor()
    {
        int layerMask = LayerMask.GetMask("Floor");
        //Vector3 rayPos = transform.position - new Vector3(0.0f, transform.lossy);
    }
    public void PlayerDamage(Player player)
    {
        player.Damage(_attackPower);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // 壁にぶつかったら向きを変える
        if (collision.gameObject.CompareTag("Wall"))
        {
            _moveDirection.x *= -1; // 左→右、右→左 に反転
            // 画像の向きも反転させたい場合
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
    }
}
