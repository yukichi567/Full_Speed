using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    //[SerializeField] float _xspeed = 6f;
    [SerializeField] float _yspeed = 6f;


    //��ʊX�ł͍s�����Ȃ�
    Renderer targetRenderer;
    //�v���[���[�Ƃ̋���
    [SerializeField] float _tagetarea = 15f;

    [Header("�d��")] public float gravity;
    GameObject PlayerObject;
    Vector2 PlayerPosition;
    Vector2 EnemyPosotion;
    private Rigidbody2D _rb = null;

    [SerializeField] float _lifeTime = 3f;

    void Start()
    {
        PlayerObject = GameObject.FindWithTag("Player");
        PlayerPosition = PlayerObject.transform.position;
        EnemyPosotion = transform.position;
        _rb = GetComponent<Rigidbody2D>();
        targetRenderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        PlayerPosition = PlayerObject.transform.position;
        EnemyPosotion = transform.position;
        float distance = Vector2.Distance(EnemyPosotion, PlayerPosition);


        if (targetRenderer.isVisible && distance < _tagetarea)
        {

            _rb.velocity = (PlayerPosition - EnemyPosotion).normalized * _yspeed;
            //_rb.velocity = Vector2.right * _xspeed;
        }


        if (distance < _tagetarea && PlayerPosition.y > EnemyPosotion.y)
        {
            Destroy(this.gameObject, _lifeTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == ("Wall"))
        {

            Destroy(gameObject);
        }
    }


}
