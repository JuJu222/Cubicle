using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{

    public static int scoreValue = 0;

    public int increase = 1;
    public float lastUpdate;
    Text score;
    // Start is called before the first frame update
    void Start()
    {
        score = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - lastUpdate >= 1f)
        {
            scoreValue += increase;
            lastUpdate = Time.time;
        }
        
        score.text = "Score: " + scoreValue;
    }

    void Awake()
    {
        score = GetComponent<Text>();
        scoreValue = 0;
    }
}
