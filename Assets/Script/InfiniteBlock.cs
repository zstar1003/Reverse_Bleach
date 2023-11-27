using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteBlock : MonoBehaviour
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
            // �����ɵ����ɵ�ͼ��
            GameObject newMapBlock = Instantiate(selectedMapBlock, generationPoint.position, Quaternion.identity);
            // ���ƶ��ű���ӵ����ɵĵ�ͼ����
            DestoryItself movementScript = newMapBlock.AddComponent<DestoryItself>();
        }
    }
}


