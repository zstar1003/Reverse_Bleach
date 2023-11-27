using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleRotation : MonoBehaviour
{
    public float rotationSpeed = 50f; // ��ת�ٶ�
    public float minRotation = 0f; // ��С��ת�Ƕ�
    public float maxRotation = 360f; // �����ת�Ƕ�
    public float minRotationSpeed = 20f; // ��С��ת�ٶ�
    public float maxRotationSpeed = 100f; // �����ת�ٶ�



    void Start()
    {
        float randomRotation = Random.Range(minRotation, maxRotation);
        transform.rotation = Quaternion.Euler(0f, 0f, randomRotation);
        float randomRotationSpeed = Random.Range(minRotationSpeed, maxRotationSpeed);
        // �� Update ��������ת�ٶ�
        GetComponent<ObstacleRotation>().rotationSpeed = randomRotationSpeed;
    }



    void Update()
    {
        // ʹ����Χ�� Z ����ת
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }
}
