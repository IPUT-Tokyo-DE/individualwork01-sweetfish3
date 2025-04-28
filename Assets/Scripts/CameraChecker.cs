using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChecker : MonoBehaviour
{
    private enum Mode // Enum�^�i�񋓌^�j�F���O�̕t�����萔�̏W�܂�B�����̏����ŏ������s���������ȂǂɎg��
    {
        None,
        Render,
        RenderOut,
    }

    private Mode _mode;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _mode = Mode.None; // �����l
    }

    // Update is called once per frame
    void Update()
    {
        _Dead();
    }

    private void OnWillRenderObject() // Unity���ŗp�ӂ���Ă��郁�\�b�h�@Render�R���|�[�l���g�������Ă���I�u�W�F�N�g���J�����Ɏʂ��Ă���ԌĂ΂�鏈��
    {
        if (Camera.current.name == "Main Camera") // Enemy�I�u�W�F�N�g���f�����J������MainCamera��������mode�l��Render�ɂ���
        {
            _mode = Mode.Render;
        }
    }

    private void _Dead()
    {
        if (_mode == Mode.RenderOut)
        {
            Destroy(gameObject);
        }

        if (_mode == Mode.Render)
        {
            _mode = Mode.RenderOut;
        }
    }
}
