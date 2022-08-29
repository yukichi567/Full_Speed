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

    [Header("重力")] public float gravity;
    GameObject PlayerObject;     
    Vector2 PlayeyPosition;
    Vector2 EnemyPosotion;
    private Rigidbody2D _rb = null;

    [SerializeField] float _lifeTime = 3f;

    /// <summary>Destroy時に表示されるエフェクト</summary>
    [SerializeField] GameObject m_effectPrefab = default;
    public int dir = 1;

    void Start()
    {        
        PlayerObject = GameObject.FindWithTag("Player");
        PlayeyPosition = PlayerObject.transform.position;
        EnemyPosotion = transform.position;
        _rb = GetComponent<Rigidbody2D>();
        targetRenderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        PlayeyPosition = PlayerObject.transform.position;
        EnemyPosotion = transform.position;
        float distance = Vector2.Distance(EnemyPosotion, PlayeyPosition);

        if (targetRenderer.isVisible && distance < _tagetarea)
        {

            _rb.velocity = Vector2.up * _yspeed;
            //_rb.velocity = Vector2.right * _xspeed;
        }

        if (distance < _tagetarea && PlayeyPosition.y > EnemyPosotion.y)
        {
            Destroy(this.gameObject, _lifeTime);
            
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == ("Wall"))
        {

            Destroy(gameObject);
            Instantiate(m_effectPrefab, transform.position, transform.rotation);
        }
    }

    
}
