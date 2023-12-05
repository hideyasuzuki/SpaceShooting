using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static Score instance;
    public int score;  //Score�ϐ����`
    //�X�N���v�g���A�^�b�`�������ɃX�R�A���Z������Text�ƕR�Â���
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
        score = 0;  //�X�^�[�g���̕\��
    }

    // Update is called once per frame
    void Update()
    {
        ScoreText.text = string.Format("{0}", score);  //Text�̃t�H�[�}�b�g
    }
}
