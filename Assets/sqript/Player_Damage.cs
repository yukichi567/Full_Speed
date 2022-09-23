using UnityEngine;
using UnityEngine.UI;

public class Player_Damage : MonoBehaviour
{
    //HP & HPgage
    [SerializeField] Image _life;
    [SerializeField] public float _hp = 5f;
    float _maxhp = 1f;

    //DamageCooltime
    [SerializeField] Text _timerlimit;
    [SerializeField] float _Damagetimer = 1;

    [SerializeField] GameObject explosionEffect = null;


    GameManager _time;
    Road_Speed _rs;
    // Start is called before the first frame update
    void Start()
    {
        _rs = GameObject.FindObjectOfType<Road_Speed>();
        _time = GameObject.FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        _Damagetimer += Time.deltaTime;
        _life.GetComponent<Image>().fillAmount = _maxhp;

        //_ContinueTime += Time.deltaTime;

        //if (_hp <= 0)
        //{
        //     //GameObject go = Instantiate(explosionEffect);
        //    _timerlimit.gameObject.SetActive(true);
        //    Road_Speed._scrollSpeed = 0;
        //    PlayerController._PlayerSpeed = 0;
        //    //_background.gameObject.SetActive(true);
        //    //_gameover.gameObject.SetActive(true);
        //    _time.gameObject.SetActive(true);
        //    //_Continue.gameObject.SetActive(true);

        //    //_GameOvertime.text = $"{_ContinueTime.ToString("F0")}";
        //}


            
            //Destroy(this.gameObject);   // Ž©•ª‚ð”jŠü‚·‚é


    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (_Damagetimer >= 1 && collision.gameObject.tag == "Enemy" )
        {
            _rs._scrollSpeed = 10;


        }
        else if (_Damagetimer >= 1 && collision.gameObject.tag == "Wall" || collision.gameObject.tag == "Truck")
        {
            _hp -= 1;
            _Damagetimer = 0;
            _maxhp -= 0.2f;
            _rs._scrollSpeed = 10;
            //_time._time += 3;
        }
        else if (_Damagetimer >= 1 && collision.gameObject.tag == "Police")
        {
            _hp -= 2;
            _Damagetimer = 0;
            _maxhp -= 0.4f;
            _rs._scrollSpeed = 10;
           // _time._time -= 10;

        }

    }
        
    private void Gameover()
    {
        //_gameovertimer += Time.deltaTime;
        //_ContinueCount = 10 - _gameovertimer;
        //_timerlimit.text = $"{_ContinueCount.ToString("F1")}";
    }
}

