using UnityEngine;
using UnityEngine.SceneManagement; // �V�[���������[�h���邽�߂Ɏg���܂��i�K�v�ɉ����āj

public class PlayerFallChecker : MonoBehaviour
{
    public float fallThreshold = -10f; // ����Y���W��艺�ɗ�������Q�[���I�[�o�[

    void Update()
    {
        if (transform.position.y < fallThreshold)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        Debug.Log("�Q�[���I�[�o�[�I");

        // �Ⴆ�΁A���݂̃V�[���������[�h���ă��X�^�[�g����Ȃ�F
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        // �܂��́A�Q�[���I�[�o�[��ʂ��o���Ȃǂ̏������������Ƃ��ł��܂��B
    }
}

