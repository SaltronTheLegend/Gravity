using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeGameOverLogic : MonoBehaviour
{
    public int countDownValue = 180;
    public Text timerUI;
    public GameOverScreen gameOverScreen;

    public void GameOver()
    {
        gameOverScreen.Setup();
    }

    // Start is called before the first frame update
    void Start()
    {
        countDownTimer();
    }

    void countDownTimer()
    {
        if (countDownValue > 0)
        {
            TimeSpan spanTime = TimeSpan.FromSeconds(countDownValue);
            timerUI.text = " Time : " + spanTime.Minutes + " : " + spanTime.Seconds;
            countDownValue--;
            Invoke("countDownTimer", 1.0f);
        }
        else
        {
            timerUI.text = "Time : 0 : 0";
            GameOver();
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Debug.Log("GameOver!");
        }

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
