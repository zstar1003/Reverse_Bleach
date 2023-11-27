using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackRange : MonoBehaviour
{
    private Animator animator;
    private bool isDestroyed;

    void Start()
    {
        animator = GetComponentInChildren<Animator>(); // 获取子物体上的 Animator 组件
        isDestroyed = false;
    }


    void Update()
    {
        // 检查动画是否播放完成
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        // 如果动画已经播放一半
        if (stateInfo.normalizedTime >= 0.5f && stateInfo.IsName("Boom"))
        {   
            // 销毁对象
            Destroy(gameObject);
         
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
       if (!isDestroyed && other.CompareTag("PlayerAttack"))
       {
           isDestroyed = true;
           animator.SetTrigger("Boom"); // 播放命名为 "Boom" 的动画触发器
       }
    }

}
