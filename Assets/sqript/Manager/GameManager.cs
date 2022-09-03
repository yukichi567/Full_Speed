using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;




    public float _Point ;
 
    [SerializeField]
    [Header("経過時間")]
    public float _count;
    public float _time ;
    //[SerializeField] Text _Timer;
    [SerializeField] Text _timerlimit;


    [SerializeField]
    [Header("プレイ時間の初期値")]
    private float _GameOverTime = 60f;

    [Header("ゲームオーバー画面")]
    [SerializeField] GameObject gameover = null;

    int score = 0;
    [SerializeField]  Text _score;
     
    GameObject P2;
    GameObject PD;
    GameObject TM;
    Road_Speed _scrollSpeed;
    float _EnemyPoint;

    /// <summary>スコア表示用 Text</summary>

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

        _Point = 0;
        //if (gameover)
        //{
        //    gameover.enabled = false;
        //}
    }

    private void Update()
    {
        _Point += _scrollSpeed._scrollSpeed / 10;

        _time += Time.deltaTime;
        _count = _GameOverTime - _time;
        //_timerlimit.text = $"{_count.ToString("F1")}";

        _score.text = $"{_Point.ToString("F0")}";

       // _score.text = score.ToString();

        //if (_count <= 0 )
        //{
        //    _scrollSpeed._scrollSpeed = 0;
        //}

    }

    public void Point(int i )
    {
        _Point += i;
    }

}