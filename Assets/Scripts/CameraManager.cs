using System.Collections;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField, Header("�U�����鎞��")]
    private float _shakeTime;
    [SerializeField, Header("�U���̑傫��")]
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

    private void _ShakeCheck() // ���݂�HP���v���C���[��HP�ƈ�v���Ă���̂�
    {
        if(_currentPlayerHP != _player.GetHP()) // ���݂�HP���v���C���[��HP�Ɠ������Ȃ��ꍇ
        {
            _currentPlayerHP = _player.GetHP();
            _shakeCount = 0.0f;�@// �����l�ɂ���
            StartCoroutine(_Shake());
        }
    }

    IEnumerator _Shake()
    {
        Vector3 initPos = transform.position; // transform.position�̓J�����I�u�W�F�N�g

        while (_shakeCount < _shakeTime)
        {
            // �����_���Œl���o�����Ƃ𗐐�
            // shakeMagnitude = 1�̏ꍇ�A-1�`1�̊Ԃ������_���̒l�ŏo��
            float x = initPos.x + Random.Range(-_shakeMagnitude, _shakeMagnitude);
            float y = initPos.x + Random.Range(-_shakeMagnitude, _shakeMagnitude);
            transform.position = new Vector3(x, y, initPos.z);

            _shakeCount += Time.deltaTime;

            yield return null; // �����𒆒f���Ď��̃t���[������ĊJ����
        }

        transform.position = initPos;
    }

    // ��{�J�����̓v���C���[��X���W�Ɠ����ʒu�ɂ��邪�����ʒu��X���W��菬�������W(Mathf.Clamp�̍ŏ��l)�ɂ͂Ȃ�Ȃ�
    private void _FollowPlayer()
    {
        if (_player != null)
        {
            float x = _player.transform.position.x;
            x = Mathf.Clamp(x, _initPos.x, Mathf.Infinity); // Mathf.Infinity:�����̖�����
            transform.position = new Vector3(x, transform.position.y, transform.position.z);
        }
       
    }
}
