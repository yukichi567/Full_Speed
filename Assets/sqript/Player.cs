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
        float h = Input.GetAxisRaw("Horizontal");   // 垂直方向の入力を取得する
        float v = Input.GetAxisRaw("Vertical");     // 水平方向の入力を取得する
        Vector2 dir = new Vector2(h, v).normalized; // 進行方向の単位ベクトルを作る (dir = direction) 
        m_rb.velocity = dir * speed;

    }
}
