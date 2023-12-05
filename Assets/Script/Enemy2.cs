using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Enemy2 : MonoBehaviour
{
    Score score;
    float x;                       //三角関数の数値設定
    float speed = 3f;              //スピードの数値設
    float radius = 0.1f;           //半径の設定
    float destroyLine = -5f;
    const float MOVE_MAX_X = 2.3f;
    const float MOVE_MAX_Y = 6f;
    void Start()
    {
        score = GameObject.Find("Score").GetComponent<Score>();
    }

    // Update is called once per frame
    void Update()
    {
        x = radius * Mathf.Sin(Time.time * speed);  //三角関数による動きの設定。

        //X座標のみ三角関数による動きの設定を反映
        transform.position = new Vector3(x + transform.position.x, -speed * Time.deltaTime + transform.position.y, transform.position.z);
        float newX = Mathf.Clamp(transform.localPosition.x, -MOVE_MAX_X, MOVE_MAX_X);
        float newY = Mathf.Clamp(transform.localPosition.y, -MOVE_MAX_Y, MOVE_MAX_Y);
        transform.localPosition = new Vector3(newX, newY, 0);

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
        if (collision != null)
        {
            if (collision.gameObject.tag == "PlayerBullet")
            {
                score.score += 100;
                GameObjectDestroy(gameObject);
            }
            if (collision.gameObject.tag == "Player")
            {
                GameObjectDestroy(gameObject);
            }
        }
    }
}
