using System.Collections;
using UnityEngine;

public class InfiniteMapGenerator : MonoBehaviour
{
    public GameObject[] mapBlockPrefabs; // ��ͼ��Ԥ��������
    public float intervalTime = 2f; // ����ʱ����
    public Transform generationPoint; // ���ɵ�


    void Start()
    {
        StartCoroutine("GenerateMapBlock");
    }

    IEnumerator GenerateMapBlock()
    {
        while (true)
        {
            yield return new WaitForSeconds(intervalTime);

            // ���ѡ��һ����ͼ��Ԥ����
            GameObject selectedMapBlock = mapBlockPrefabs[Random.Range(0, mapBlockPrefabs.Length)];

            // �����ת
            Quaternion randomRotation = Quaternion.Euler(0f, 0f, Random.Range(0f, 360f));

            // �����ɵ����ɵ�ͼ��
            GameObject newMapBlock = Instantiate(selectedMapBlock, generationPoint.position, Quaternion.identity);

            // ���ƶ��ű���ӵ����ɵĵ�ͼ����
            MapBlockMovement movementScript = newMapBlock.AddComponent<MapBlockMovement>();

            // ���ø���Ϊ��ǰ����
            newMapBlock.transform.parent = transform;
        }
    }
}

// ��ͼ���ƶ��ű�
public class MapBlockMovement : MonoBehaviour
{
    void Update()
    {
        // �����ƶ���ͼ��
        transform.Translate(Vector3.left * Global.groundSpeed * Time.deltaTime);

        // �����ͼ���Ƴ���Ļ�⣬��������
        if (transform.position.x < -20f) // ����� -20f ��һ��������������ĳ����ߴ���е���
        {
            Destroy(gameObject);
        }
    }
}
