using UnityEngine;
using UnityEngine.SceneManagement; // シーンをリロードするために使います（必要に応じて）

public class PlayerFallChecker : MonoBehaviour
{
    public float fallThreshold = -10f; // このY座標より下に落ちたらゲームオーバー

    void Update()
    {
        if (transform.position.y < fallThreshold)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        Debug.Log("ゲームオーバー！");

        // 例えば、現在のシーンをリロードしてリスタートするなら：
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        // または、ゲームオーバー画面を出すなどの処理を書くこともできます。
    }
}

