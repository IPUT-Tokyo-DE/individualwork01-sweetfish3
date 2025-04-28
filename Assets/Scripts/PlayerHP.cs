using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    public GameObject hpPrefab; // �Ԋۃv���n�u
    public int hpMax = 5;
    public float spacing = 30f; // �̗̓A�C�R���̊Ԋu

    [SerializeField, Header("HP�A�C�R��")]
    private GameObject _playerIcon;

    private Player _player;
    private int _beforeHP;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        _player = FindObjectOfType<Player>(); // �v���C���[�X�N���v�g���擾����
        _beforeHP = _player.GetHP();
        _CreateHPIcon();
        
        //for (int i = 0; i < hpMax; i++)
        //{
        //    GameObject hp = Instantiate(hpPrefab, transform);
        //    hp.transform.localPosition = new Vector3(i * spacing, 0, 0);
        //    // �����ŁuX�����v�ɕ��ׂĂ���
        //}
        
    }

    private void _CreateHPIcon()
    {
        for (int i = 0; i < _player.GetHP(); i++)
        {
            GameObject _playerHPObj = Instantiate(_playerIcon, transform);
            _playerHPObj.transform.localPosition = new Vector3(i * 30f, 0, 0); // ��X�����ɂ��炷
        }
    }


    // Update is called once per frame
    void Update()
    {
        _ShowHPIcon();
    }

    private void _ShowHPIcon()
    {
        if (_beforeHP == _player.GetHP()) return; // ���݂̃v���C���[�̗̑͂Ɠ����������ꍇ���^�[������

        Image[] icons = transform.GetComponentsInChildren<Image>(); // Image�z��^
        for (int i = 0; i < icons.Length; i++)
        {
            icons[i].gameObject.SetActive(i < _player.GetHP());
        }
        _beforeHP = _player.GetHP();
    }
}
