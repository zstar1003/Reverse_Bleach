using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateGround : MonoBehaviour
{
    public GameObject groundPrefab; // �ϰ���Ԥ�Ƽ�
    public float spawnInterval = 0.1f; // ���ɼ��ʱ��
    public float startDelay = 0.1f; // ��ʼ���ɵ��ӳ�ʱ��


    void Start()
    {
        // ����Э�̣����ڲ��������ϰ���
        StartCoroutine(SpawnObstacles());
    }

    IEnumerator SpawnObstacles()
    {
        yield return new WaitForSeconds(startDelay);

        while (true)
        {
            // �����ϰ��ﲢ��� Ground ���
            GameObject newObstacle = Instantiate(groundPrefab, transform.position, Quaternion.identity);
            newObstacle.AddComponent<Ground>();

            yield return new WaitForSeconds(spawnInterval);
        }
    }


}
public class Global
{
    public static float groundSpeed = 5;

    public static void IncreaseSpeed(float incrementAmount)
    {
        groundSpeed += incrementAmount;
    }
}
