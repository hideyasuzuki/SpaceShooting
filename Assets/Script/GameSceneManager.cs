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
        // ��ʂ��t�F�[�h�C��������R�[���`��
        // �O��F��ʂ𕢂�Panel�ɃA�^�b�`���Ă���
        if(GameObject.Find("Fade") != null)
        {
            Image fade = GameObject.Find("Fade").GetComponent<Image>();

            // �t�F�[�h���̐F��ݒ�i���j���ύX��
            fade.color = new Color((0.0f / 255.0f), (0.0f / 255.0f), (0.0f / 0.0f), (255.0f / 255.0f));

            // �t�F�[�h�C���ɂ����鎞�ԁi�b�j���ύX��
            const float fade_time = 2.0f;

            // ���[�v�񐔁i0�̓G���[�j���ύX��
            const int loop_count = 10;

            // �E�F�C�g���ԎZ�o
            float wait_time = fade_time / loop_count;

            // �F�̊Ԋu���Z�o
            float alpha_interval = 255.0f / loop_count;

            // �F�����X�ɕς��郋�[�v
            for (float alpha = 255.0f; alpha >= 0.0f; alpha -= alpha_interval)
            {
                // �҂�����
                yield return new WaitForSeconds(wait_time);

                // Alpha�l��������������
                Color new_color = fade.color;
                new_color.a = alpha / 255.0f;
                fade.color = new_color;
            }
        }
    }
}
