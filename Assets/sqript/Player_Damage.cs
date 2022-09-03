using UnityEngine;
using UnityEngine.UI;

public class Player_Damage : MonoBehaviour
{
    //HP & HPgage
    [SerializeField] Image _Life;
    [SerializeField] public int _HP = 5;
    float _MaxHp = 1f;

    //DamageCooltime
    [SerializeField] Text _timerlimit;
    [SerializeField] float _Damagetimer = 1;

    //gameover
    [SerializeField] Image _BackGround;
    [SerializeField] Image _GameOver;
    public float _GameOvertimer;
    public float _ContinueCount;
    [SerializeField] Text _GameOvertime;
    [SerializeField] Button _Continue;
     float _ContinueTime;
    [SerializeField] GameObject explosionEffect = null;
    GameObject PM;
    GameObject RM;

    //Road_Speed variable
    Road_Speed _scrollSpeed;
    PlayerController _PlayerSpeed;
    GameManager _time;
    // Start is called before the first frame update
    void Start()
    {
        PM = GameObject.Find("Player");
        RM = GameObject.Find("Road");
        _scrollSpeed = GameObject.FindObjectOfType<Road_Speed>();
        _PlayerSpeed = GameObject.FindObjectOfType<PlayerController>();
        _time = GameObject.FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        _Damagetimer += Time.deltaTime;
        _Life.GetComponent<Image>().fillAmount = _MaxHp;;

        _ContinueTime += Time.deltaTime;

        if (_HP <= 0)
        {
             //GameObject go = Instantiate(explosionEffect);
            _timerlimit.gameObject.SetActive(true);
            _scrollSpeed._scrollSpeed = 0;
            _PlayerSpeed._PlayerSpeed = 0;
            _BackGround.gameObject.SetActive(true);
            _GameOver.gameObject.SetActive(true);
            _time.gameObject.SetActive(true);
            _Continue.gameObject.SetActive(true);

            _GameOvertime.text = $"{_ContinueTime.ToString("F0")}";
        }


            
            //Destroy(this.gameObject);   // ������j������


    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (_Damagetimer >= 1 && collision.gameObject.tag == "Enemy" )
        {
                //_HP -= 1;
                //_Damagetimer = 0;
                //_MaxHp -= 0.2f;
                _scrollSpeed._scrollSpeed = 10;


        }
        else if (_Damagetimer >= 1 && collision.gameObject.tag == "Wall" || collision.gameObject.tag == "Truck")
        {
            _HP -= 1;
            _Damagetimer = 0;
            _MaxHp -= 0.2f;
            _scrollSpeed._scrollSpeed = 10;
            //_time._time += 3;
        }
        else if (_Damagetimer >= 1 && collision.gameObject.tag == "Police")
        {
                _HP -= 2;
                _Damagetimer = 0;
                _MaxHp -= 0.4f;
                _scrollSpeed._scrollSpeed = 10;
           // _time._time -= 10;

        }

    }
        
    private void Gameover()
    {
        _GameOvertimer += Time.deltaTime;
        _ContinueCount = 10 - _GameOvertimer;
        _timerlimit.text = $"{_ContinueCount.ToString("F1")}";
    }
}

