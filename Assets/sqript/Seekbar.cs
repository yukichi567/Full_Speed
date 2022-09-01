using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Seekbar : MonoBehaviour
{
    [SerializeField]
    [Header("シークバー")]
    Slider _TimeSlider;
    public float _time;
    public float _gameOverTime;

    //Start is called before the first frame update
    void Start()
    {
        //_time = GameObject.FindObjectOfType<GameManager>();
        //_gameOverTime = GameObject.FindObjectOfType<GameManager>();
        _TimeSlider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        //_TimeSlider = _time / _gameOverTime;
    }
}
