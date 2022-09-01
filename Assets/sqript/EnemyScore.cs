using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScore : MonoBehaviour
{

    //scoreä÷åW
    [Header("â¡éZÉXÉRÉA")] public int _EnemyScore;


    GameObject RS;
    // Start is called before the first frame update
    // Update is called once per frame

    private void Start()
    {
        var RM = GameObject.Find("Road");
    }
    void Update()
    {
        //var RS = RM.GetComponent<Road_Speed>();
        //_scrollSpeed = RS._scrollSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //New!
        if (GameManager.instance != null)
        {
           // GameManager.instance.score += _EnemyScore;
            Destroy(this.gameObject);
       }
    }
}
