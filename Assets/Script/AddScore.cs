using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddScore : MonoBehaviour
{
    [SerializeField]  Score score;
    int status;

    void Start()
    {
        score = GameObject.Find("Score").GetComponent<Score>();
        status = 0;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (status == 0)
        {
            score.score += 100;
            Destroy(this.gameObject);
        }
    }
}
