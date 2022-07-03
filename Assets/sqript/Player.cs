using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] public float speed = 0f;
    Rigidbody2D m_rb;


    // Start is called before the first frame update
    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");   // ���������̓��͂��擾����
        float v = Input.GetAxisRaw("Vertical");     // ���������̓��͂��擾����
        Vector2 dir = new Vector2(h, v).normalized; // �i�s�����̒P�ʃx�N�g������� (dir = direction) 
        m_rb.velocity = dir * speed;

    }
}
