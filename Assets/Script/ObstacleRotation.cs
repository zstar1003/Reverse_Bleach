using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleRotation : MonoBehaviour
{
    public float rotationSpeed = 50f; // 旋转速度
    public float minRotation = 0f; // 最小旋转角度
    public float maxRotation = 360f; // 最大旋转角度
    public float minRotationSpeed = 20f; // 最小旋转速度
    public float maxRotationSpeed = 100f; // 最大旋转速度



    void Start()
    {
        float randomRotation = Random.Range(minRotation, maxRotation);
        transform.rotation = Quaternion.Euler(0f, 0f, randomRotation);
        float randomRotationSpeed = Random.Range(minRotationSpeed, maxRotationSpeed);
        // 在 Update 中设置旋转速度
        GetComponent<ObstacleRotation>().rotationSpeed = randomRotationSpeed;
    }



    void Update()
    {
        // 使物体围绕 Z 轴旋转
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }
}
