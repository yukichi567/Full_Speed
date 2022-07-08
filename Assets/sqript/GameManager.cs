using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public int score;
    public int stageNum;
    public int continueNum;


    float _time;
    [SerializeField] Text Timer;

    // Start is called before the first frame update
    private void Awake()
    {

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        _time += Time.deltaTime;
        float time = 60 - _time;
        Timer.text = $"{time.ToString("f1")}";


    }
}