using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField, Header("移動速度")]
    private float _moveSpeed = 5f;
    [SerializeField, Header("ジャンプ速度")]
    private float _jumpSpeed = 5f;

    [SerializeField, Header("ジャンプ力")]
    private float _jumpForce = 7f;

    [SerializeField, Header("体力")]
    private int _hp;

    private Rigidbody2D _rigid;
    private bool _isGrounded;

    private void Start()
    {
        _rigid = GetComponent<Rigidbody2D>();
        _isGrounded = false;
    }

    private void Update()
    {
        Move();
        Jump();
        _HitFloor();
    }

    private void Move()
    {
        float h = Input.GetAxis("Horizontal");
        _rigid.linearVelocity = new Vector2(h * _moveSpeed, _rigid.linearVelocity.y);
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            _rigid.linearVelocity = new Vector2(_rigid.linearVelocity.x, _jumpForce);
        }
    }

    // 地面に着地した時
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if (collision.gameObject.CompareTag("Ground"))
        //{
        //    _isGrounded = true;
        //}
        if (collision.gameObject.CompareTag("Enemy"))
        {
            _HitEnemy(collision);
            gameObject.layer = LayerMask.NameToLayer("PlayerDamage");
        }
    }

    private void _HitFloor()
    {
        int layerMask = LayerMask.GetMask("Floor");
        Vector3 rayPos = transform.position - new Vector3(0.0f, transform.lossyScale.y / 2.0f);
        Vector3 raySize = new Vector3(transform.lossyScale.x - 0.1f, 0.1f);
        RaycastHit2D rayHit = Physics2D.BoxCast(rayPos, raySize, 0.0f, Vector2.zero, 0.0f, layerMask);
        if (rayHit.transform == null)
        {
            _isGrounded = true;
            return;
        }
        if (rayHit.transform.tag == "Floor" && _isGrounded)
        {
            _isGrounded = false;
        }
    }

    private void _HitEnemy(Collision2D collision)
    {
        GameObject enemy = collision.gameObject;

        // 接触したポイントを調べる
        ContactPoint2D contact = collision.GetContact(0);

        // 接触の法線を調べる
        Vector2 normal = contact.normal;

        // 上からぶつかったかどうか
        if (normal.y > 0.5f)  // 法線が上向きなら、上から踏んだ
        {
            // 上から踏んだので、敵を倒す
            Destroy(enemy);
            _rigid.AddForce(Vector2.up * _jumpSpeed, ForceMode2D.Impulse);
        }
        else
        {
            // 横や下からぶつかった → ダメージ
            enemy.GetComponent<Enemy>().PlayerDamage(this);
        }
    }

    private void _Dead()
    {
        if(_hp <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnBecameInvisible() // オブジェクトがカメラの外に出た瞬間に呼ばれるメソッド
    {
        Camera camera = Camera.main;
        if (camera.name == "Main Camera" && camera.transform.position.y > transform.position.y)
        {
            Destroy(gameObject);
        }    
    }

    public void Damage(int damage)
    {
        _hp = Mathf.Max(_hp - damage, 0);
        _Dead();
    }

    public int GetHP()
    {
        return _hp;
    }
   
}
