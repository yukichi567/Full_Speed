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
        _TimeSlider.maxValue = 60.0f;
        _TimeSlider.value = _TimeSlider.maxValue;
    }

    // Update is called once per frame
    void Update()
    {
        //_time += ;
        _TimeSlider.value = _TimeSlider.value - Time.deltaTime;
    }

}
