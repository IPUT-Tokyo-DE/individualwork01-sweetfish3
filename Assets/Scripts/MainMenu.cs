using UnityEngine;
using UnityEngine.SceneManagement; // シーン切り替えに必要

public class MainMenu : MonoBehaviour
{
    private void OnMouseDown()
    {
        Debug.Log("スタートオブジェクトがクリックされた！");

        // 本編のシーンをロードする（シーン名は実際の名前に合わせて！）
        SceneManager.LoadScene("StartScene");
    }
}
