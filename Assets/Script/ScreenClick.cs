using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenClick : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
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
