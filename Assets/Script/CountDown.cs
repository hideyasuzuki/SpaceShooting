using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{
    public float countdown = 60.0f;
    bool stopTimerFlag = false;
    //���Ԃ�\������Text�^�̕ϐ�
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
        //���Ԃ��J�E���g�_�E������
        countdown -= Time.deltaTime;

        //���Ԃ�\������
        timeText.text = countdown.ToString("f0") + "�b";
    }
}
