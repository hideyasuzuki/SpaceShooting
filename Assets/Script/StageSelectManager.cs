using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageSelectManager : MonoBehaviour
{
    public void StageSelect(int stage)
    {
        SceneManager.LoadScene(stage);
    }
}
