using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
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
    private Rigidbody2D rb = null;

    [SerializeField] float m_lifeTime = 3f;

    void Start()
    {        
        PlayerObject = GameObject.FindWithTag("Player");
        PlayeyPosition = PlayerObject.transform.position;
        EnemyPosotion = transform.position;
        rb = GetComponent<Rigidbody2D>();
        targetRenderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayeyPosition = PlayerObject.transform.position;
        EnemyPosotion = transform.position;
        float distance = Vector2.Distance(EnemyPosotion, PlayeyPosition);
        int xVector = -1;

        if (targetRenderer.isVisible && distance < _tagetarea)
        {

            Debug.Log("1111");
            xVector = 3;
            transform.localScale = new Vector3(-1, 1, 1);
            rb.velocity = new Vector2(xVector * _xspeed, -gravity);
        }
        else if ( distance > _tagetarea)
        {
            Debug.Log("0000");

        }


        if (distance < _tagetarea && PlayeyPosition.y > EnemyPosotion.y)
        {
            Destroy(this.gameObject, m_lifeTime);
        }

    }
}
