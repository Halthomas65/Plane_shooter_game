using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCount : MonoBehaviour
{
    public Text scoreText;
    public int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + score;        
    }

    public void AddScore(int scoreToAdd = 1)
    {
        score += scoreToAdd;
    }
}
