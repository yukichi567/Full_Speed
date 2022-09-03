using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerSlider : MonoBehaviour
{
    float t = 0;
    Slider slider;

    void Start()
    {
        //txt = (GameObject.Find("Text")).GetComponent<Text>();
        slider = (GameObject.Find("Slider")).GetComponent<Slider>();
        slider.maxValue = 60.0f;
    }
    //true a;


    void Update()
    {

        t = slider.value;


        t -= Time.deltaTime;

    }

}