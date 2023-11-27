using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1WithGravity : MonoBehaviour
{
    public Vector2 gravityDirection = Vector2.down; // ��ʼ������������
    private Rigidbody2D rb;
    private GravityManager gravityManager;
    private bool hasCollided = false; // ���һ�������������¼��Ƿ��Ѵ�����
    private PhysicsCheck physicsCheck;
    private Animator animator;
    public BoxCollider2D boxCollider;
    private GameObject player;
    private bool skillUsed = false; // ���ڸ��ټ����Ƿ��Ѿ�ʹ�ù�
    public GameObject skillStatusMask; // ��ק����״̬ mask ���󵽴��ֶ�
    public AudioSource audioSource; // �� Inspector �����з����ɫ�� AudioSource ���
    public AudioClip skillSound; // �� Inspector �����з����ɫ���ܵ���Ƶ����




    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gravityManager = FindObjectOfType<GravityManager>(); // ��ȡ�����е� GravityManager
        physicsCheck = GetComponent<PhysicsCheck>();

        player = this.gameObject;

        // �����弰������������ӵ�������
        if (gravityManager != null)
        {
            gravityManager.AddObjectWithGravity(rb, gravityDirection);
        }
        // ��ȡ Animator ���������
        animator = GetComponent<Animator>();
        // �ڿ�ʼʱ��ȡ BoxCollider2D ���������
        boxCollider = GetComponent<BoxCollider2D>();

    }

    void Update()
    {
        Vector2 center = transform.position; // ��ȡ��ǰ����λ����Ϊ�����������ĵ�
        Vector2 size = new Vector2(1, 1); // ���ü������ĳߴ�

        Collider2D collider = Physics2D.OverlapBox(center, size, 0f); // ���һ���������Ƿ�����ײ��

        if (!hasCollided) // ����Ƿ��Ѿ���������ײ�¼�
        {
            if (collider != null && collider.CompareTag("Player2"))
            {
                // ִ�нӴ���Ĳ���
                Vector3 currentScale = transform.localScale;
                currentScale.y *= -1; // ��תy��
                transform.localScale = currentScale;
                hasCollided = true;
            }
        }
        if (physicsCheck.isDownGround)
        {
            // ���������¼������簴��F������Ҳ���Ը���Ϊ����������
            if (Input.GetKeyDown(KeyCode.F) && !skillUsed)
            {
                // ���ü���״̬Ϊ��ʹ��
                skillUsed = true;
                // ���� Animator �е� isSkill ����Ϊ true
                animator.SetBool("inskill", true);
                // ���� Rigidbody2D ���
                rb.simulated = false;
                // �����������λ��
                player.transform.position = new Vector2(-5.03f, -1.04f);
                // ���ż�����ʾ��Ч
                if (audioSource != null && skillSound != null)
                {
                    audioSource.PlayOneShot(skillSound);
                }
                else
                {
                    Debug.LogWarning("AudioSource or Skill Tip Sound not assigned in the Inspector.");
                }
            }
        }

        if (physicsCheck != null && (physicsCheck.isDownGround || physicsCheck.isUpGround))
        {
            hasCollided = false;
        }

        if (physicsCheck != null && physicsCheck.isUpGround)
        {
            skillUsed = false;
        }
        if (skillStatusMask != null && physicsCheck.isDownGround && skillUsed == false)
        {
            // ���ݼ���״̬���Ƽ���״̬ mask ����ʾ������
            skillStatusMask.SetActive(false); // ������δʹ��ʱ��ʾ mask����������
        }
        if (skillStatusMask != null && physicsCheck.isUpGround || skillUsed == true)
        {
            // ���ݼ���״̬���Ƽ���״̬ mask ����ʾ������
            skillStatusMask.SetActive(true); // ������δʹ��ʱ��ʾ mask����������
        }
    }

 

    public void ResetSkill()
    {
        animator.SetBool("inskill", false);
        rb.simulated = true;
        // �����������λ��
        player.transform.position = new Vector2(-7.93f, -3.41f);
    }

    public void MovePlayer()
    {
        // �����������λ��
        player.transform.position = new Vector2(-0.93f, -0.25f);
    }
}