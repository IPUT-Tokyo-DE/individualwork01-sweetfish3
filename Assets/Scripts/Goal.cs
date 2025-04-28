using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement; // シーン遷移にはこれが必要！

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
