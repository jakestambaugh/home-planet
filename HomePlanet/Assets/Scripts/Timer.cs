using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(HighScore))]
public class Timer : MonoBehaviour
{
    public TextMeshProUGUI clueText;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI scoreText;
    public float timerLength;
    private int score;
    private HighScore highScore;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        highScore = GetComponent<HighScore>();
    }

    // Update is called once per frame
    void Update()
    {
        timerLength -= Time.deltaTime;
        if(timerLength <= 0f) {
            highScore.SetHighScore(score);
            clueText.SetText("Press P to restart!");
            Time.timeScale = 0f;
        }
        else {
            UpdateText(RenderTime(timerLength));
        }
    }

    private string RenderTime(float delta) {
        float minutes = Mathf.Floor(delta / 60);
        float seconds = Mathf.RoundToInt(delta % 60);
        return string.Format("{0:0}:{1:00}", minutes, seconds);
    }

    private void UpdateText(string minutesAndSeconds) {
        timerText.text = "Time: " + minutesAndSeconds;
        scoreText.text = "Score: " + score;
    }

    public void UpdateScore(){
        score = score + 1;
    }
}



