using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //
    [SerializeField] float _xspeed = 6f;
    [SerializeField] float _yspeed = 6f;

    //画面街では行動しない
    Renderer targetRenderer;
    //プレーヤーとの距離
    [SerializeField] float _tagetarea = 15f;
    [SerializeField] float _tagetarea2 = 100f;

    GameObject PlayerObject;     
    Vector2 PlayerPosition;
    Vector2 EnemyPosotion;
    private Rigidbody2D _rb = null;

    [SerializeField] float _lifeTime = 1f;
    [SerializeField] int _score;
    GameManager _gamemanager;
    /// <summary>Destroy時に表示されるエフェクト</summary>
    [SerializeField] GameObject m_effectPrefab = default;
    public int dir = 1;
    [SerializeField] GameManager _EnemyPoint;

    void Start()
    {
        //GetChildren(this.Roed);
        PlayerObject = GameObject.FindWithTag("Player");
        PlayerPosition = PlayerObject.transform.position;
        EnemyPosotion = transform.position;
        _rb = GetComponent<Rigidbody2D>();
        targetRenderer = GetComponent<Renderer>();
        PlayerPosition = PlayerObject.transform.position;
        EnemyPosotion = transform.position;
        _gamemanager = GameObject.FindObjectOfType<GameManager>();
        // _EnemyPoint = GameObject.FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        PlayerPosition = PlayerObject.transform.position;
        EnemyPosotion = transform.position;
        float distance = Vector2.Distance(EnemyPosotion, PlayerPosition);

        if ( distance < _tagetarea)
        {
             _rb.velocity = Vector2.up * _yspeed;
            //_rb.velocity = (PlayerPosition - EnemyPosotion).normalized. * _yspeed;
            //_rb.velocity = Vector2.right * _xspeed;
        }
        else
        {
            _rb.velocity = Vector2.up *  0;
        }

        if ( distance > _tagetarea2  )
        {
            Destroy(this.gameObject, _lifeTime);
            
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
      
        if (collision.gameObject.tag == ("Wall") && targetRenderer.isVisible)
        {
            _gamemanager.AddScore(_score);
            Destroy(gameObject);
            Instantiate(m_effectPrefab, transform.position, transform.rotation);
        }

        else if (collision.gameObject.tag == ("Player"))
        {
            if (PlayerPosition.x > EnemyPosotion.x)
            {
                _rb.velocity = Vector2.right * _xspeed;
            }
            else if (PlayerPosition.x < EnemyPosotion.x)
            {
                _rb.velocity = Vector2.left * _xspeed;
            }
        }
    }

    
}
