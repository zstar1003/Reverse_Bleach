using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateGround : MonoBehaviour
{
    public GameObject groundPrefab; // 障碍物预制件
    public float spawnInterval = 0.1f; // 生成间隔时间
    public float startDelay = 0.1f; // 开始生成的延迟时间


    void Start()
    {
        // 启动协程，用于不断生成障碍物
        StartCoroutine(SpawnObstacles());
    }

    IEnumerator SpawnObstacles()
    {
        yield return new WaitForSeconds(startDelay);

        while (true)
        {
            // 生成障碍物并添加 Ground 组件
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
