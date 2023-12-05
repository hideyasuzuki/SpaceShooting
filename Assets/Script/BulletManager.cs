using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    [SerializeField] GameObject playerBullet = null;
    [SerializeField] CountDown countDown = null;
    float time = 0;
    float instanceTime = 0.5f;
    
    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(countDown != null)
        {
            if(countDown.countdown > 0)
            {
                PlayerBulletInstance(playerBullet);
            }
        }
    }

    void PlayerBulletInstance(GameObject bullet)
    {
        if(bullet != null)
        {
            if(time > instanceTime)
            {
                Instantiate(bullet, transform.position, Quaternion.identity);
                time = 0;
            }
            
        }
    }
}
