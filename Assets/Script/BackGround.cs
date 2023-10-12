using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    Vector3 startPos = new Vector2();
    [SerializeField] float resetPos = 0f;
    
    void Awake()
    {
        startPos = transform.position;
    }

    void FixedUpdate()
    {
        float speed = 2;
        transform.Translate(0, -speed * Time.deltaTime, 0, Space.World);

        if (resetPos >= transform.position.y)
        {
            transform.position = startPos;
        }
    }
}
