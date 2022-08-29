using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    /// <summary>無敵モード</summary>
    [SerializeField] bool m_godMode = false;
    

    [SerializeField] Image _Life;
    [SerializeField] public int _HP = 5;
    [SerializeField] Text _timerlimit;
    [SerializeField] float _Damagetimer = 1;

    float _MaxHp = 1f;
    [SerializeField] GameObject explosionEffect = null;

    [SerializeField] public float _PlayerSpeed = 5f;
    Rigidbody2D _rb;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");   // 垂直方向の入力を取得する
        float v = Input.GetAxisRaw("Vertical");     // 水平方向の入力を取得する
        Vector2 dir = new Vector2(h, v).normalized; // 進行方向の単位ベクトルを作る (dir = direction) 
        _rb.velocity = dir * _PlayerSpeed;

        _Damagetimer += Time.deltaTime;
        _Life.GetComponent<Image>().fillAmount = _MaxHp; ;
        //var RS = RM.GetComponent<Road_Speed>();
        //_scrollSpeed = RS._scrollSpeed;
        if (_HP <= 0)
        {
            _timerlimit.gameObject.SetActive(true);
            //RS._scrollSpeed -= 0;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (_Damagetimer >= 1 && collision.gameObject.tag == "Enemy" || _Damagetimer >= 1 && collision.gameObject.tag == "Wall")
        {
            _HP -= 1;
            _Damagetimer = 0;
            _MaxHp -= 0.2f;
            //_scrollSpeed -= 10;
        }
        else if (_Damagetimer >= 1 && collision.gameObject.tag == "Police")
        {
            _HP -= 2;
            _Damagetimer = 0;
            _MaxHp -= 0.4f;
            //_scrollSpeed -= 10;
        }

        if(_HP == 0)
        {
            if (explosionEffect)
            {
                GameObject go = Instantiate(explosionEffect);
                go.transform.position = this.transform.position;
            }

            // GameManager にやられたことを知らせる
            GameManager gm = GameObject.FindObjectOfType<GameManager>();
            //if (gm)
            //{
            //    gm.PlayerDead();
            //}

            Destroy(this.gameObject);   // 自分を破棄する
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

    }
}
