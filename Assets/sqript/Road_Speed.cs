using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road_Speed : MonoBehaviour
{
    /// <summary>�X�N���[������X�s�[�h</summary>
    [SerializeField] float _scrollSpeed;
    /// <summary>���܂ōs�����炱�̈ʒu�Ƀ��Z�b�g�����</summary>
    Vector3 _restartPos = new Vector3(0, 10, 0);
    /// <summary>�����܂ŗ�����ʒu�����Z�b�g����</summary>
    Vector3 _endPos = new Vector3(0, -400, 0);



    void Start()
    {
     
    }

    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * _scrollSpeed);
        if (transform.position.y < _endPos.y)
            transform.position = _restartPos;

        if (Input.GetKeyDown(KeyCode.Space)  && _scrollSpeed < 60)
        {
            _scrollSpeed += 10;
        }
        else if (Input.GetKeyDown(KeyCode.LeftShift) && _scrollSpeed > 10)
        {
            _scrollSpeed -= 10;
        }
    }
}
