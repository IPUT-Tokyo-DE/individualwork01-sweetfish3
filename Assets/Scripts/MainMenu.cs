using UnityEngine;
using UnityEngine.SceneManagement; // �V�[���؂�ւ��ɕK�v

public class MainMenu : MonoBehaviour
{
    private void OnMouseDown()
    {
        Debug.Log("�X�^�[�g�I�u�W�F�N�g���N���b�N���ꂽ�I");

        // �{�҂̃V�[�������[�h����i�V�[�����͎��ۂ̖��O�ɍ��킹�āI�j
        SceneManager.LoadScene("StartScene");
    }
}
