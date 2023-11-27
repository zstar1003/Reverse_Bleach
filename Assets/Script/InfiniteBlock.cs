using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteBlock : MonoBehaviour
{
    public GameObject[] mapBlockPrefabs; // 地图块预制体数组
    public float intervalTime = 2f; // 生成时间间隔
    public Transform generationPoint; // 生成点

    void Start()
    {
        StartCoroutine("GenerateMapBlock");
    }

    IEnumerator GenerateMapBlock()
    {
        while (true)
        {
            yield return new WaitForSeconds(intervalTime);

            // 随机选择一个地图块预制体
            GameObject selectedMapBlock = mapBlockPrefabs[Random.Range(0, mapBlockPrefabs.Length)];
            // 在生成点生成地图块
            GameObject newMapBlock = Instantiate(selectedMapBlock, generationPoint.position, Quaternion.identity);
            // 将移动脚本添加到生成的地图块上
            DestoryItself movementScript = newMapBlock.AddComponent<DestoryItself>();
        }
    }
}


