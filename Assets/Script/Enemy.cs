using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Score score;
    float speed = 3.0f;
    float destroyLine = -6.0f;
    // Start is called before the first frame update
    void Start()
    {
        score  = GameObject.Find("Score").GetComponent<Score>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, -speed * Time.deltaTime, 0);

        if (transform.position.y <= destroyLine)
        {
            GameObjectDestroy(gameObject);
        }
    }

    void GameObjectDestroy(GameObject gameObject)
    {
        if (gameObject != null)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision != null)
        {
            if(collision.gameObject.tag == "PlayerBullet")
            {
                score.score += 100;
                GameObjectDestroy(gameObject);
            }
            if(collision.gameObject.tag == "Player")
            {
                GameObjectDestroy(gameObject);
            }
        }
    }
}
