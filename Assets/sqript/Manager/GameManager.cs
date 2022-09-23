using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public float _Point;

    [SerializeField]
    [Header("�o�ߎ���")]
    public float _count;
    public float _time;

    [Header("���ԕ\��")]
    [SerializeField] Text _timerlimit;

    [SerializeField]
    [Header("�v���C���Ԃ̏����l")]
    public float _GameOverTime = 60f;

    [Header("�N���A�A�Q�[���I�[�o�[�摜")]
    [SerializeField]
    GameObject _gameover;
    [SerializeField]
    GameObject _gameclear;
    [SerializeField]
    GameObject _generater;

    [Header("�X�R�A")]
    [SerializeField]
    public float _score = 0f;
    Text _scoretext;
    int score;

    [Header("��script")]
    Player_Damage _playerdamage;
    Road_Speed _roadspeed;
    PlayerController _playercontroller;

    float _EnemyPoint;
    bool _isGame = true;

    /// <summary>�X�R�A�\���p Text</summary>

    // Start is called before the first frame update

    private void Start()
    {
        _Point = 0;
        _playerdamage = GameObject.FindObjectOfType<Player_Damage>();
        _roadspeed = GameObject.FindObjectOfType<Road_Speed>();
        _playercontroller = GameObject.FindObjectOfType<PlayerController>();
        _scoretext = GameObject.Find("Score").GetComponent<Text>();
    }

    private void Update()
    {
        if (_isGame)
        {
            _score += _roadspeed._scrollSpeed / 10;
            _time += Time.deltaTime;
            _count = _GameOverTime - _time;

            _scoretext.text = $"{_score.ToString("F0")}";

            if (_count <= 0)
            {
                _isGame = false;
                _gameclear.gameObject.SetActive(true);
                _playercontroller._PlayerSpeed = 0;
                _generater.gameObject.SetActive(false);
            }

            if (_playerdamage._hp <= 0)
            {
                _isGame = false;
                _gameover.gameObject.SetActive(true);
                _roadspeed._scrollSpeed = 0;
                _roadspeed._meterspeet = 0;
                _playercontroller._PlayerSpeed = 0;
                _generater.gameObject.SetActive(false);
            }
        }
        else if (_isGame == false)
        {

        }
    }

    public void AddScore(int score)
    {
        _score += score;
    }
}