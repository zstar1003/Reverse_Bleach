using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryItself : MonoBehaviour
{
    void Update()
    {
        // �����ͼ���Ƴ���Ļ�⣬��������
        if (transform.position.x < -20f) // ����� -20f ��һ��������������ĳ����ߴ���е���
        {
            Destroy(gameObject);
        }
    }
}
