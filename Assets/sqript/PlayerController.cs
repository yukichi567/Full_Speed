using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    /// <summary>���G���[�h</summary>
    [SerializeField] bool m_godMode = false;
    [SerializeField] public float _PlayerSpeed = 10f;
    Rigidbody2D _rb;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");   // ���������̓��͂��擾����
        float v = Input.GetAxisRaw("Vertical");     // ���������̓��͂��擾����
        Vector2 dir = new Vector2(h, v).normalized; // �i�s�����̒P�ʃx�N�g������� (dir = direction) 
        _rb.velocity = dir * _PlayerSpeed;

       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

    }
}
