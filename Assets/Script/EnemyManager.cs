using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] GameObject[] enemyPrefab = new GameObject[3];
    //���ԊԊu�̍ŏ��l
    [SerializeField] float minTime = 2f;
    //���ԊԊu�̍ő�l
    [SerializeField] float maxTime = 5f;
    //Y���W�̍ŏ��l
    [SerializeField] float yMinPosition = 0f;
    //Y���W�̍ő�l
    [SerializeField] float yMaxPosition = 10f;
    //X���W�̍ŏ��l
    float xMinPosition = -2f;
    //X���W�̍ő�l
    float xMaxPosition = 2f;
    //�G�������ԊԊu
    private float interval;
    //�o�ߎ���
    private float time = 0f;
    // Start is called before the first frame update
    void Start()
    {
        //���ԊԊu�����肷��
        interval = GetRandomTime();
    }

    // Update is called once per frame
    void Update()
    {
        //���Ԍv��
        time += Time.deltaTime;

        //�o�ߎ��Ԃ��������ԂɂȂ����Ƃ�(�������Ԃ��傫���Ȃ����Ƃ�)
        if (time > interval)
        {
            int enemyNumber = Random.Range(0, enemyPrefab.Length);
            //enemy���C���X�^���X������(��������)
            GameObject enemy = Instantiate(enemyPrefab[enemyNumber], transform.position, transform.rotation);
            if (enemyNumber == 1)
            {
                enemy.transform.position = GetRandomPosition2();
                time = 0f;
                interval = GetRandomTime();
                return;
            }
            //���������G�̈ʒu�������_���ɐݒ肷��
            enemy.transform.position = GetRandomPosition();
            //�o�ߎ��Ԃ����������čēx���Ԍv�����n�߂�
            time = 0f;
            //���ɔ������鎞�ԊԊu�����肷��
            interval = GetRandomTime();
        }
    }

    //�����_���Ȏ��Ԃ𐶐�����֐�
    private float GetRandomTime()
    {
        return Random.Range(minTime, maxTime);
    }

    //�����_���Ȉʒu�𐶐�����֐�
    private Vector3 GetRandomPosition()
    {
        //���ꂼ��̍��W�������_���ɐ�������
        float x = Random.Range(xMinPosition, xMaxPosition);
        float y = Random.Range(yMinPosition, yMaxPosition);
        //Vector3�^��Position��Ԃ�
        return new Vector3(x, y, 0);
    }

    Vector3 GetRandomPosition2()
    {
        float x = Random.Range(xMinPosition + 2f, xMaxPosition -2f);
        float y = Random.Range(yMinPosition, yMaxPosition);
        return new Vector3(x, y, 0);
    }

}
