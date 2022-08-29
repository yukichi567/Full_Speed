using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    public int stageNum;
    public int continueNum;

    Road_Speed _scrollSpeed;
    float _speed;

    public float _count;
    public float _time = 60f;
   [SerializeField] Text _Timer;


    [SerializeField] Text _score;
    public int score;

    GameObject P2;
    GameObject PD;
    GameObject TM;
    [SerializeField] float _timer;
    [SerializeField] Text _timerlimit;

    /// <summary>スコア表示用 Text</summary>

        /// <summary>GameOver 表示用 Text</summary>
    [SerializeField] GameObject gameover = null;



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
        //RM = GameObject.Find("Road");
        P2 = GameObject.Find("Player");
        TM = GameObject.Find("Time");
        _scrollSpeed = GameObject.FindObjectOfType<Road_Speed>();
        //if (gameover)
        //{
        //    gameover.enabled = false;
        //}
    }

    private void Update()
    {


        _speed += _scrollSpeed._scrollSpeed / 10;
        _timer += Time.deltaTime;
        _count = _time - _timer;
        _timerlimit.text = $"{_count.ToString("F1")}";
        _score.text = $"{_speed.ToString("F0")}";

        if(_count <= 0 )
        {
            _scrollSpeed._scrollSpeed = 0;
        }
    }


}