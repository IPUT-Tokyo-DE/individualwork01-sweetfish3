using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement; // �V�[���J�ڂɂ͂��ꂪ�K�v�I

public class Goal: MonoBehaviour
{

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene("ClearScene");
        }
    }
}
