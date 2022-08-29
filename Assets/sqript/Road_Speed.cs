using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road_Speed : MonoBehaviour
{
    /// <summary>スクロールするスピード</summary>
    [SerializeField] public float _scrollSpeed = 10f;

    /// <summary>下まで行ったらこの位置にリセットされる</summary>
    Vector3 _restartPos = new Vector3(0, 10, 0);
    /// <summary>ここまで来たら位置をリセットする</summary>
    Vector3 _endPos = new Vector3(0, -140, 0);



    void Start()
    {
     
    }

    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * _scrollSpeed);
        if (transform.position.y < _endPos.y)
            transform.position = _restartPos;

        if (Input.GetKeyDown(KeyCode.Space)  && _scrollSpeed < 30)
        {
            _scrollSpeed += 5;
        }
        //else if (Input.GetKeyDown(KeyCode.Space) && _scrollSpeed < 30 && 20 <= _scrollSpeed )
        //{
        //    _scrollSpeed += 10;
        //}

        else if (Input.GetKeyDown(KeyCode.LeftShift) && _scrollSpeed > 10)
        {
            _scrollSpeed -= 10;
        }
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == ("speed"))
        {
            //_scrollSpeed += 10;
        }
    }

}
