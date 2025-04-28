using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChecker : MonoBehaviour
{
    private enum Mode // Enum型（列挙型）：名前の付いた定数の集まり。複数の条件で処理を行いたい時などに使う
    {
        None,
        Render,
        RenderOut,
    }

    private Mode _mode;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _mode = Mode.None; // 初期値
    }

    // Update is called once per frame
    void Update()
    {
        _Dead();
    }

    private void OnWillRenderObject() // Unity側で用意されているメソッド　Renderコンポーネントが入っているオブジェクトがカメラに写っている間呼ばれる処理
    {
        if (Camera.current.name == "Main Camera") // Enemyオブジェクトが映ったカメラがMainCameraだったらmode値をRenderにする
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
