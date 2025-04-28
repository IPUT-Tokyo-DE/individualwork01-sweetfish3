using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    public GameObject hpPrefab; // 赤丸プレハブ
    public int hpMax = 5;
    public float spacing = 30f; // 体力アイコンの間隔

    [SerializeField, Header("HPアイコン")]
    private GameObject _playerIcon;

    private Player _player;
    private int _beforeHP;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        _player = FindObjectOfType<Player>(); // プレイヤースクリプトを取得する
        _beforeHP = _player.GetHP();
        _CreateHPIcon();
        
        //for (int i = 0; i < hpMax; i++)
        //{
        //    GameObject hp = Instantiate(hpPrefab, transform);
        //    hp.transform.localPosition = new Vector3(i * spacing, 0, 0);
        //    // ここで「X方向」に並べている
        //}
        
    }

    private void _CreateHPIcon()
    {
        for (int i = 0; i < _player.GetHP(); i++)
        {
            GameObject _playerHPObj = Instantiate(_playerIcon, transform);
            _playerHPObj.transform.localPosition = new Vector3(i * 30f, 0, 0); // ★X方向にずらす
        }
    }


    // Update is called once per frame
    void Update()
    {
        _ShowHPIcon();
    }

    private void _ShowHPIcon()
    {
        if (_beforeHP == _player.GetHP()) return; // 現在のプレイヤーの体力と同じだった場合リターンする

        Image[] icons = transform.GetComponentsInChildren<Image>(); // Image配列型
        for (int i = 0; i < icons.Length; i++)
        {
            icons[i].gameObject.SetActive(i < _player.GetHP());
        }
        _beforeHP = _player.GetHP();
    }
}
