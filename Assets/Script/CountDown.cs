using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{
    public float countdown = 60.0f;
    bool stopTimerFlag = false;
    //時間を表示するText型の変数
    public Text timeText;

    public bool StopTimerFlag
    {
        get { return stopTimerFlag; }
    }

    // Update is called once per frame
    void Update()
    {
        if(countdown <= 0)
        {
            countdown = 0;
            stopTimerFlag = true;
            return;
        }
        //時間をカウントダウンする
        countdown -= Time.deltaTime;

        //時間を表示する
        timeText.text = countdown.ToString("f0") + "秒";
    }
}
