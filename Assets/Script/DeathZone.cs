using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other != null)
        {
            // 检测进入死亡区域的对象是否是角色
            if (other.CompareTag("Player1") || other.CompareTag("Player2"))
            {
                GameManager.Instance.GameOver(); // 假设 GameManager 中有一个 GameOver 方法来处理游戏结束逻辑
            }
        }
    }
}
