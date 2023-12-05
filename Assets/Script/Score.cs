using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static Score instance;
    public int score;  //Score変数を定義
    //スクリプトをアタッチした時にスコア加算したいTextと紐づける
    [SerializeField] Text ScoreText;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        score = 0;  //スタート時の表示
    }

    // Update is called once per frame
    void Update()
    {
        ScoreText.text = string.Format("{0}", score);  //Textのフォーマット
    }
}
