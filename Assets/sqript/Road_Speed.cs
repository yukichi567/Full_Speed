using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road_Speed : MonoBehaviour
{
    /// <summary>�X�N���[������X�s�[�h</summary>
    [SerializeField]
    [Header("�X�N���[���X�s�[�h")]
    public static float _scrollSpeed = 10f;

    [SerializeField]
    [Header("�X�s�[�h���[�^�[")]
    GameObject _meter = null;


    [SerializeField]
    [Header("�j�̊p�x")]


    /// <summary>���܂ōs�����炱�̈ʒu�Ƀ��Z�b�g�����</summary>
    Vector3 _restartPos = new Vector3(0, 450, 0);
    /// <summary>�����܂ŗ�����ʒu�����Z�b�g����</summary>
    Vector3 _endPos = new Vector3(0, -450, 0);



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
        else if (Input.GetKeyDown(KeyCode.Space) && _scrollSpeed < 30 && 20 <= _scrollSpeed )
        {
            _scrollSpeed += 10;
        }

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
