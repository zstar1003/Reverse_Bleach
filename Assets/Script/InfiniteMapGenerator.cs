using System.Collections;
using UnityEngine;

public class InfiniteMapGenerator : MonoBehaviour
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

            // 随机旋转
            Quaternion randomRotation = Quaternion.Euler(0f, 0f, Random.Range(0f, 360f));

            // 在生成点生成地图块
            GameObject newMapBlock = Instantiate(selectedMapBlock, generationPoint.position, Quaternion.identity);

            // 将移动脚本添加到生成的地图块上
            MapBlockMovement movementScript = newMapBlock.AddComponent<MapBlockMovement>();

            // 设置父级为当前对象
            newMapBlock.transform.parent = transform;
        }
    }
}

// 地图块移动脚本
public class MapBlockMovement : MonoBehaviour
{
    void Update()
    {
        // 向左移动地图块
        transform.Translate(Vector3.left * Global.groundSpeed * Time.deltaTime);

        // 如果地图块移出屏幕外，则销毁它
        if (transform.position.x < -20f) // 这里的 -20f 是一个举例，根据你的场景尺寸进行调整
        {
            Destroy(gameObject);
        }
    }
}
