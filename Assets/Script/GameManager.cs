using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject gameClear = null;
    [SerializeField] GameObject gameOver = null;
    [SerializeField] Player player = null;
    [SerializeField] CountDown countDown = null;
    bool clearConditionsFlag = false;
    public bool ClearConditionFlag
    {
        get { return clearConditionsFlag; }
    }

    float stateTimer = 0;
    float stateTime = 3;
    // Update is called once per frame
    void Update()
    {
        if(!clearConditionsFlag)
        {
            if (player.IsPlayer == false)
            {
                Instantiate(gameOver);
                clearConditionsFlag = true;
            }
            else if (countDown.StopTimerFlag)
            {
                Instantiate(gameClear);
                clearConditionsFlag = true;
            }
        }

        if(clearConditionsFlag)
        {
            stateTimer += Time.deltaTime;
        }

        if(stateTimer > stateTime)
        {
            SceneManager.LoadScene("Result");
        }
    }
}
