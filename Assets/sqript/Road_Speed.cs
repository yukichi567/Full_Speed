using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Road_Speed : MonoBehaviour
{
    /// <summary>スクロールするスピード</summary>
    [SerializeField]
    [Header("スクロールスピード")]
    public float _scrollSpeed = 10f;

    [SerializeField]
    [Header("スピードメーター")]
    Text Speed;
    public float _meterspeet;
    float _meter;

    /// <summary>下まで行ったらこの位置にリセットされる</summary>
    Vector3 _restartPos = new Vector3(0, 450, 0);
    /// <summary>ここまで来たら位置をリセットする</summary>
    Vector3 _endPos = new Vector3(0, -450, 0);
    GameManager _gm;

    void Start()
    {
        //Speed = GameObject.Find("SpeedMeter").GetComponent<Text>();
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
        else if (Input.GetKeyDown(KeyCode.Space) && _scrollSpeed < 30 && 20 <= _scrollSpeed )
        {
            _scrollSpeed += 10;
        }

        else if (Input.GetKeyDown(KeyCode.LeftShift) && _scrollSpeed > 10)
        {
            _scrollSpeed -= 10;
        }

        _meter = _scrollSpeed + _meterspeet;
        Speed.text = $"{_meter.ToString("F0")}";

    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == ("speed"))
        {
            //_scrollSpeed += 10;
        }
    }

}
