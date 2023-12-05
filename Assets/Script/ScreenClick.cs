using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenClick : MonoBehaviour
{
    public static ScreenClick instance;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
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
        if(Input.GetMouseButtonDown(0))
        {
            if (SceneManager.GetActiveScene().name == "Title")
            {
                SceneManager.LoadScene("StageSelect");
            }
            else if(SceneManager.GetActiveScene().name == "Result")
            {
                SceneManager.LoadScene("Title");
            }
        }
    }
}
