using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    float speed = 3.0f;
    float destroyLine = -6.0f;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, -speed * Time.deltaTime, 0);
        GameObjectDestroy(gameObject);
    }

    void GameObjectDestroy(GameObject gameObject)
    {
        if (gameObject != null)
        {
            if(transform.position.y <= destroyLine)
            {
                Destroy(gameObject);
            }
        }
    }
}
