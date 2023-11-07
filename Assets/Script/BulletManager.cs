using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    [SerializeField] GameObject playerBullet = null;
    float time = 0;
    float instanceTime = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        PlayerBulletInstance(playerBullet);
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
