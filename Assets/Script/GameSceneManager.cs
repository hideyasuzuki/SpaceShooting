using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSceneManager : MonoBehaviour
{
    public static GameSceneManager Instance;
    bool isFade = false;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Title")
        {
            if (isFade == false)
            {
                StartCoroutine(Color_FadeIn());
                isFade = true;
            }

            if (Input.GetMouseButtonDown(0))
            {
                SceneManager.LoadScene("StageSelect");
                isFade = false;
            }
        }
        else if (SceneManager.GetActiveScene().name == "Result")
        {
            if (Input.GetMouseButtonDown(0))
            {
                SceneManager.LoadScene("Title");
                isFade = false;
            }
        }
        else if(SceneManager.GetActiveScene().name == "StageSelect")
        {
            if(isFade == false)
            {
                StartCoroutine(Color_FadeIn());
                isFade = true;
            }
        }
        else
        {
            return;
        }
    }

    IEnumerator Color_FadeIn()
    {
        // 画面をフェードインさせるコールチン
        // 前提：画面を覆うPanelにアタッチしている
        if(GameObject.Find("Fade") != null)
        {
            Image fade = GameObject.Find("Fade").GetComponent<Image>();

            // フェード元の色を設定（黒）★変更可
            fade.color = new Color((0.0f / 255.0f), (0.0f / 255.0f), (0.0f / 0.0f), (255.0f / 255.0f));

            // フェードインにかかる時間（秒）★変更可
            const float fade_time = 2.0f;

            // ループ回数（0はエラー）★変更可
            const int loop_count = 10;

            // ウェイト時間算出
            float wait_time = fade_time / loop_count;

            // 色の間隔を算出
            float alpha_interval = 255.0f / loop_count;

            // 色を徐々に変えるループ
            for (float alpha = 255.0f; alpha >= 0.0f; alpha -= alpha_interval)
            {
                // 待ち時間
                yield return new WaitForSeconds(wait_time);

                // Alpha値を少しずつ下げる
                Color new_color = fade.color;
                new_color.a = alpha / 255.0f;
                fade.color = new_color;
            }
        }
    }
}
