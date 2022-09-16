using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    public float _Point;

    [SerializeField]
    [Header("�o�ߎ���")]
    public float _count;
    public float _time;

    [Header("���ԕ\��")]
    [SerializeField] Text _timerlimit;

    [SerializeField]
    [Header("�v���C���Ԃ̏����l")]
    private float _GameOverTime = 60f;

    [Header("�N���A�A�Q�[���I�[�o�[�摜")]
    [SerializeField]
    GameObject _gameOver;
    [SerializeField]
    GameObject _gameClear;

    [Header("�X�R�A")]
    [SerializeField]
    int score = 0;
    [SerializeField] Text _score;

    GameObject P2;
    GameObject PD;
    GameObject TM;
    float _EnemyPoint;
    bool _isGame;

    /// <summary>�X�R�A�\���p Text</summary>

    // Start is called before the first frame update
    private void Awake()
    {

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        P2 = GameObject.Find("Player");
        TM = GameObject.Find("Time");
        _Point = 0;

    }

    private void Update()
    {
        if (_isGame)
        {
            _Point += Road_Speed._scrollSpeed / 10;
            _time += Time.deltaTime;
            _count = _GameOverTime - _time;
            //_timerlimit.text = $"{_count.ToString("F1")}";

            _score.text = $"{_Point.ToString("F0")}";

            // _score.text = score.ToString();

            //if (_count <= 0 )
            //{
            //    _scrollSpeed._scrollSpeed = 0;
            //}

            if (_count <= 0)
            {
                _isGame = false;
                _gameClear.gameObject.SetActive(true);
            }

            if (Player_Damage._hp <= 0)
            {
                _isGame = false;
                _gameOver.gameObject.SetActive(true);
                Road_Speed._scrollSpeed = 0;
                PlayerController._PlayerSpeed = 0;
                Debug.Log("aaaa");
            }
        }
        else if (_isGame == false)
        {
            //_resultTet.text = $"{_score.ToString("00000")}";
        }
    }

    public void AddScore(int score)
    {

    }
}