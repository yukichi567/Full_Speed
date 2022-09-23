using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    [SerializeField] Transform[] _Generateposition;
    [SerializeField] GameObject[] _Enemy;
    [SerializeField] float _interval;
    [SerializeField] AudioClip _bgm;
    float _timer;


    /// <summary>フィールドのオブジェクトを格納</summary>
    GameObject _field;
    GameManager _gm;

    void Start()
    {
        _field = GameObject.FindGameObjectWithTag("Road");
        _gm = GameObject.FindObjectOfType<GameManager>();
    }

    void Update()
    {
        _timer += Time.deltaTime;
        //if(_gm._time < 60 )
        //{
        //    _interval = 3f;
        //}
        //else if (_gm._time < 40)
        //{
        //    _interval = 2.3f;
        //}
        //else
        //{
        //    _interval = 1.5f;
        //}
        if (_timer > _interval)
        {
            int number = Random.Range(0, _Generateposition.Length);
            int num = Random.Range(0, _Enemy.Length);
            GameObject Car = Instantiate(_Enemy[num]);
            Car.transform.position =  _Generateposition[number].position;
            Car.transform.SetParent(_field.transform );
            _timer = 0;
        }
    }
}
