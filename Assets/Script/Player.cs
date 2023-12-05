using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] Text PlayerHitPoint;
    Vector3 previousPos, currentPos;
    float sensitivity = 1f;
    const float LOAD_WIDTH = 15f;
    const float LOAD_HEIGHT = 15f;
    const float MOVE_MAX_X = 2.3f;
    const float MOVE_MAX_Y = 4.3f;
    int hitPoint = 3;
    bool isPlayer = true;
    GameManager gameManager = null;
    public bool IsPlayer
    { 
        get { return isPlayer; } 
    }
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    void Update()
    {
        PlayerHitPoint.text = "残機" + hitPoint;
        if (Input.GetMouseButtonDown(0))
        {
            previousPos = Input.mousePosition;
        }
        if (Input.GetMouseButton(0))
        {
            // スワイプによる移動距離を取得
            currentPos = Input.mousePosition;
            float diffDistanceX = (currentPos.x - previousPos.x) / Screen.width * LOAD_WIDTH;
            float diffDistanceY = (currentPos.y - previousPos.y) / Screen.width * LOAD_HEIGHT;
            diffDistanceX *= sensitivity;
            diffDistanceY *= sensitivity;

            // 次のローカル座標を設定 ※道の外にでないように
            float newX = Mathf.Clamp(transform.localPosition.x + diffDistanceX, -MOVE_MAX_X, MOVE_MAX_X);
            float newY = Mathf.Clamp(transform.localPosition.y + diffDistanceY, -MOVE_MAX_Y, MOVE_MAX_Y);
            transform.localPosition = new Vector3(newX, newY, 0);

            // タップ位置を更新
            previousPos = currentPos;
        }
    }

    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = -Camera.main.transform.position.z;
        return Camera.main.ScreenToWorldPoint(mousePos);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
            if (hitPoint <= 0 && gameManager.ClearConditionFlag == false)
            {
                Destroy(gameObject);
                isPlayer = false;
            }
            if (collision.gameObject.tag == "Enemy")
            {
                hitPoint--;
            }
        }
    }
}
