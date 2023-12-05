using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] GameObject[] enemyPrefab = new GameObject[3];
    //時間間隔の最小値
    [SerializeField] float minTime = 2f;
    //時間間隔の最大値
    [SerializeField] float maxTime = 5f;
    //Y座標の最小値
    [SerializeField] float yMinPosition = 0f;
    //Y座標の最大値
    [SerializeField] float yMaxPosition = 10f;
    //X座標の最小値
    float xMinPosition = -2f;
    //X座標の最大値
    float xMaxPosition = 2f;
    //敵生成時間間隔
    private float interval;
    //経過時間
    private float time = 0f;
    // Start is called before the first frame update
    void Start()
    {
        //時間間隔を決定する
        interval = GetRandomTime();
    }

    // Update is called once per frame
    void Update()
    {
        //時間計測
        time += Time.deltaTime;

        //経過時間が生成時間になったとき(生成時間より大きくなったとき)
        if (time > interval)
        {
            int enemyNumber = Random.Range(0, enemyPrefab.Length);
            //enemyをインスタンス化する(生成する)
            GameObject enemy = Instantiate(enemyPrefab[enemyNumber], transform.position, transform.rotation);
            if (enemyNumber == 1)
            {
                enemy.transform.position = GetRandomPosition2();
                time = 0f;
                interval = GetRandomTime();
                return;
            }
            //生成した敵の位置をランダムに設定する
            enemy.transform.position = GetRandomPosition();
            //経過時間を初期化して再度時間計測を始める
            time = 0f;
            //次に発生する時間間隔を決定する
            interval = GetRandomTime();
        }
    }

    //ランダムな時間を生成する関数
    private float GetRandomTime()
    {
        return Random.Range(minTime, maxTime);
    }

    //ランダムな位置を生成する関数
    private Vector3 GetRandomPosition()
    {
        //それぞれの座標をランダムに生成する
        float x = Random.Range(xMinPosition, xMaxPosition);
        float y = Random.Range(yMinPosition, yMaxPosition);
        //Vector3型のPositionを返す
        return new Vector3(x, y, 0);
    }

    Vector3 GetRandomPosition2()
    {
        float x = Random.Range(xMinPosition + 2f, xMaxPosition -2f);
        float y = Random.Range(yMinPosition, yMaxPosition);
        return new Vector3(x, y, 0);
    }

}
