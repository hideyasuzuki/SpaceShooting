using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullets : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (GetComponent<Renderer>().isVisible == false)
        {
            Destroy(gameObject);
        }

        float speed = 10.0f * Time.deltaTime;
        transform.Translate(0.0f, speed, 0.0f);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }
}
