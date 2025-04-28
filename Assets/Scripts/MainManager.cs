using UnityEngine;

public class MainManager : MonoBehaviour
{
    [SerializeField, Header("ゲームオーバーUI")]
    private GameObject _gameOverUI;
    private GameObject _player;

    public float fallThreshold = -10f;

    public GameObject player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _player = FindObjectOfType<Player>().gameObject;
        _gameOverUI.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        _ShowGameOverUI();
        if (player != null)
        {
            if (player.transform.position.y < -10)
            {
                _gameOverUI.SetActive(true);
            }

        }
        
    }

    private void _ShowGameOverUI()
    {
        if (_player != null) return;

        _gameOverUI.SetActive(true);
    }
}
