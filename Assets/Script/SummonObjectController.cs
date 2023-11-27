using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonObjectController : MonoBehaviour
{
    public AudioSource audioSource; // �� Inspector �����з����ɫ�� AudioSource ���
    public AudioClip skillSound; // �� Inspector �����з����ɫ���ܵ���Ƶ����

    void Start()
    {
        audioSource.PlayOneShot(skillSound);
    }

    // �������������ʱ���ø÷���
    public void DestroySummonObject()
    {
        // �����ٻ������
        Destroy(gameObject);
    }
}
