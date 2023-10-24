using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Vector3 offset;
    public float sensitivity = 1f;
    const float LOAD_WIDTH = 10f;
    const float LOAD_HEIGHT = 10f;
    const float MOVE_MAX_X = 8f;
    const float MOVE_MAX_Y = 4.3f;
    Vector3 previousPos, currentPos;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            previousPos = Input.mousePosition;
        }
        if (Input.GetMouseButton(0))
        {
            // �X���C�v�ɂ��ړ��������擾
            currentPos = Input.mousePosition;
            float diffDistanceX = (currentPos.x - previousPos.x) / Screen.width * LOAD_WIDTH;
            float diffDistanceY = (currentPos.y - previousPos.y) / Screen.width * LOAD_HEIGHT;
            diffDistanceX *= sensitivity;
            diffDistanceY *= sensitivity;

            // ���̃��[�J��x���W��ݒ� �����̊O�ɂłȂ��悤��
            float newX = Mathf.Clamp(transform.localPosition.x + diffDistanceX, -MOVE_MAX_X, MOVE_MAX_X);
            float newY = Mathf.Clamp(transform.localPosition.y + diffDistanceY, -MOVE_MAX_Y, MOVE_MAX_Y);
            transform.localPosition = new Vector3(newX, newY, 0);

            // �^�b�v�ʒu���X�V
            previousPos = currentPos;
        }
    }

    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = -Camera.main.transform.position.z;
        return Camera.main.ScreenToWorldPoint(mousePos);
    }
}
