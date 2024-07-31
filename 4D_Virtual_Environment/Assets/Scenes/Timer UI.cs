using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimerUI : MonoBehaviour
{
    public float timeRemaining = 600; // 10 minutes in seconds
    public Text timerText;
    [SerializeField] TMP_Text timer;

    void Update()
    {
        //counts down time and displays it
        if (timeRemaining > 0){
            timeRemaining -= Time.deltaTime;
            DisplayTime(timeRemaining);
        }
        else
        {
            timer.text = "Time's up!";
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        //formats the time properly to be displayed
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timer.text = string.Format("Time Left: "+"{0:00}:{1:00}", minutes, seconds);
    }
}
