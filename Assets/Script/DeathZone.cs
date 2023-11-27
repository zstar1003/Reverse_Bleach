using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other != null)
        {
            // ��������������Ķ����Ƿ��ǽ�ɫ
            if (other.CompareTag("Player1") || other.CompareTag("Player2"))
            {
                GameManager.Instance.GameOver(); // ���� GameManager ����һ�� GameOver ������������Ϸ�����߼�
            }
        }
    }
}
