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

    private void Awake()
    {
        //SoundManager.Instance.PlayBGM(_bgm);
    }

    void Update()
    {
        _timer += Time.deltaTime;
        if (_timer > _interval)
        {
            int number = Random.Range(0, _Generateposition.Length);
            int num = Random.Range(0, _Enemy.Length);
            Instantiate(_Enemy[num], _Generateposition[number]);
            _timer = 0;
        }
    }
}
