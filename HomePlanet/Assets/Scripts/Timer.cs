﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI scoreText;
    private float startTime;
    private int score;
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        float t = Time.time - startTime;
        string seconds = " ";
        string minute = (2 - ((int)t / 60)).ToString();
        if ((58 - (t % 60) + 1) > 10)
        {
            seconds = (58 - (t % 60) + 1).ToString("f0");
        }
        else
        {
            seconds = "0" + (58 - (t % 60) + 1).ToString("f0");
        }
        if ((2 - (int)t / 60) <= 0 && (58 - (t % 60  + 1) <= 0))  {
            Time.timeScale = 0;
        }
        if ((58 - (t % 60) + 1) > 0 && !seconds.Equals("010"))
        {
            timerText.text = "Time: " + minute + ":" + seconds;
            scoreText.text = "Score: " + score;
        }
    }

    public void UpdateScore(){
        score = score + 1;
    }
}


