using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    /// <summary>�X�N���[������X�s�[�h</summary>
    [SerializeField] float _tagetarea = 15f;
    [SerializeField] float _yokoidou = 1f;
    GameObject PlayerObject;
    Vector2 PlayeyPosition;
    Vector2 EnemyPosotion;

    // Start is called before the first frame update

    void Start()
    {
        PlayerObject = GameObject.FindWithTag("Player");
        PlayeyPosition = PlayerObject.transform.position;
        EnemyPosotion = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        PlayeyPosition = PlayerObject.transform.position;
        EnemyPosotion = transform.position;
        float distance = Vector2.Distance(EnemyPosotion, PlayeyPosition);

        if (distance < _tagetarea && PlayeyPosition.x > EnemyPosotion.x)
        {
            Debug.Log("���E�ɓ���");
            EnemyPosotion.x = EnemyPosotion.x + _yokoidou * 1f;
        }
        else if (distance < _tagetarea && PlayeyPosition.x < EnemyPosotion.x)
        {
            EnemyPosotion.x = EnemyPosotion.x - _yokoidou * 1f;
        }
    }
}
