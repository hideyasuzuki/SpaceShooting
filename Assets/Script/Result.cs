using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Result : MonoBehaviour
{
    [SerializeField] Text ResultScoreText;
    int resultScore = 0;
    // Start is called before the first frame update
    void Start()
    {
        resultScore = Score.instance.score;
    }

    // Update is called once per frame
    void Update()
    {
        ResultScoreText.text = string.Format("{0}",resultScore);
    }
}
