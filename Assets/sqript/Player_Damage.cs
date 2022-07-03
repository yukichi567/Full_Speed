using UnityEngine;
using UnityEngine.UI;

public class Player_Damage : MonoBehaviour
{
    [SerializeField] Image _Life;
    [SerializeField] int _Hp = 5;
    [SerializeField] Image _BackGround;
    [SerializeField] Image _GameOver;
    [SerializeField] Text _time;
    [SerializeField] Image _Continue;
    [SerializeField] float _timer = 1;


    float _MaxHp = 1f;

    GameObject PM;
    //スタートボタン設定


    // Start is called before the first frame update
    void Start()
    {
        PM = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;


        if (_Hp <= 0)
        {
            _BackGround.gameObject.SetActive(true);
            _GameOver.gameObject.SetActive(true);
            _time.gameObject.SetActive(true);
            _Continue.gameObject.SetActive(true);

        }

    }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (_timer >= 1 && collision.gameObject.tag == "Enemy" || _timer >= 1 && collision.gameObject.tag == "Wall")
            {
                _Hp -= 1;
                _timer = 0;
                _MaxHp -= 0.2f;
            }
            else if (_timer >= 1 && collision.gameObject.tag == "Police")
            {
                _Hp -= 2;
                _timer = 0;
                _MaxHp -= 0.4f;
                
            }

    }
        
    private void OnTriggerEnter2D(Collider2D collision)
    {

    }

}

