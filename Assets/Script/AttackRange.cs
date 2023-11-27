using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackRange : MonoBehaviour
{
    private Animator animator;
    private bool isDestroyed;

    void Start()
    {
        animator = GetComponentInChildren<Animator>(); // ��ȡ�������ϵ� Animator ���
        isDestroyed = false;
    }


    void Update()
    {
        // ��鶯���Ƿ񲥷����
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        // ��������Ѿ�����һ��
        if (stateInfo.normalizedTime >= 0.5f && stateInfo.IsName("Boom"))
        {   
            // ���ٶ���
            Destroy(gameObject);
         
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
       if (!isDestroyed && other.CompareTag("PlayerAttack"))
       {
           isDestroyed = true;
           animator.SetTrigger("Boom"); // ��������Ϊ "Boom" �Ķ���������
       }
    }

}
