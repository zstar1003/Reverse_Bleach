using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonObjectController : MonoBehaviour
{
    public AudioSource audioSource; // 在 Inspector 窗口中分配角色的 AudioSource 组件
    public AudioClip skillSound; // 在 Inspector 窗口中分配角色技能的音频剪辑

    void Start()
    {
        audioSource.PlayOneShot(skillSound);
    }

    // 当动画播放完成时调用该方法
    public void DestroySummonObject()
    {
        // 销毁召唤物对象
        Destroy(gameObject);
    }
}
