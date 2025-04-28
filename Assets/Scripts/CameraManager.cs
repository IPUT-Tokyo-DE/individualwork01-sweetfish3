using System.Collections;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField, Header("振動する時間")]
    private float _shakeTime;
    [SerializeField, Header("振動の大きさ")]
    private float _shakeMagnitude;

    private Player _player;
    private Vector3 _initPos;
    private float _shakeCount;
    private float _currentPlayerHP;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _player = FindObjectOfType<Player>();
        _currentPlayerHP = _player.GetHP();
        _initPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        _ShakeCheck();
        _FollowPlayer();
    }

    private void _ShakeCheck() // 現在のHPがプレイヤーのHPと一致しているのか
    {
        if(_currentPlayerHP != _player.GetHP()) // 現在のHPがプレイヤーのHPと等しくない場合
        {
            _currentPlayerHP = _player.GetHP();
            _shakeCount = 0.0f;　// 初期値にする
            StartCoroutine(_Shake());
        }
    }

    IEnumerator _Shake()
    {
        Vector3 initPos = transform.position; // transform.positionはカメラオブジェクト

        while (_shakeCount < _shakeTime)
        {
            // ランダムで値を出すことを乱数
            // shakeMagnitude = 1の場合、-1～1の間をランダムの値で出す
            float x = initPos.x + Random.Range(-_shakeMagnitude, _shakeMagnitude);
            float y = initPos.x + Random.Range(-_shakeMagnitude, _shakeMagnitude);
            transform.position = new Vector3(x, y, initPos.z);

            _shakeCount += Time.deltaTime;

            yield return null; // 処理を中断して次のフレームから再開する
        }

        transform.position = initPos;
    }

    // 基本カメラはプレイヤーのX座標と同じ位置にいるが初期位置のX座標より小さい座標(Mathf.Clampの最小値)にはならない
    private void _FollowPlayer()
    {
        if (_player != null)
        {
            float x = _player.transform.position.x;
            x = Mathf.Clamp(x, _initPos.x, Mathf.Infinity); // Mathf.Infinity:正数の無限大
            transform.position = new Vector3(x, transform.position.y, transform.position.z);
        }
       
    }
}
