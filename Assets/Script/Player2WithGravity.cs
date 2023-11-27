using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2WithGravity : MonoBehaviour
{
    public Vector2 gravityDirection = Vector2.up; // ��ʼ������������
    public GameObject summonPrefab; // �ٻ����Ԥ����
    private Rigidbody2D rb;
    private GravityManager gravityManager;
    private bool hasCollided = false; // ���һ�������������¼��Ƿ��Ѵ�����
    private PhysicsCheck physicsCheck;
    private Animator animator;
    private Vector2 zh_positon;
    private bool skillUsed = false; // ���ڸ��ټ����Ƿ��Ѿ�ʹ�ù�
    public GameObject skillStatusMask; // ��ק����״̬ mask ���󵽴��ֶ�
    public AudioSource audioSource; // �� Inspector �����з����ɫ�� AudioSource ���
    public AudioClip skillSound; // �� Inspector �����з����ɫ���ܵ���Ƶ����
    public float playbackSpeed = 1.0f; // ������Ƶ�Ĳ����ٶ�


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gravityManager = FindObjectOfType<GravityManager>(); // ��ȡ�����е� GravityManager
        physicsCheck = GetComponent<PhysicsCheck>();

        // �����弰������������ӵ�������
        if (gravityManager != null)
        {
            gravityManager.AddObjectWithGravity(rb, gravityDirection);
        }
        // ��ȡ Animator ���������
        animator = GetComponent<Animator>();
    }
    
    void Update()
    {
        Vector2 center = transform.position; // ��ȡ��ǰ����λ����Ϊ�����������ĵ�
        Vector2 size = new Vector2(1, 1); // ���ü������ĳߴ�

        Collider2D collider = Physics2D.OverlapBox(center, size, 0f); // ���һ���������Ƿ�����ײ��

        if (!hasCollided) // ����Ƿ��Ѿ���������ײ�¼�
        {
            if (collider != null && collider.CompareTag("Player1"))
            {
                // ִ�нӴ���Ĳ���
                Vector3 currentScale = transform.localScale;
                currentScale.y *= -1; // ��תy��
                transform.localScale = currentScale;
                hasCollided = true;
            }
        }
        if (physicsCheck.isUpGround && !skillUsed)
        {
            // ���������¼������簴��5������Ҳ���Ը���Ϊ����������
            if (Input.GetKeyDown(KeyCode.Keypad5))
            {
                // ���ü���״̬Ϊ��ʹ��
                skillUsed = true;
                // ���� Animator �е� isSkill ����Ϊ true
                animator.SetBool("inskill", true);
                // ʵ�����ٻ���
                zh_positon = new Vector2(2.54f, -0.25f);
                GameObject summonObject = Instantiate(summonPrefab, zh_positon, Quaternion.identity);
                // ����z����ת
                summonObject.transform.Rotate(0f, 0f, 90f);
                // ���ż�����ʾ��Ч
                if (audioSource != null && skillSound != null)
                {
                    audioSource.PlayOneShot(skillSound);
                    // ������Ƶ�Ĳ����ٶ�
                    audioSource.pitch = playbackSpeed;
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

        if (physicsCheck != null && physicsCheck.isDownGround)
        {
            skillUsed = false;
        }
        if (skillStatusMask != null && physicsCheck.isUpGround && skillUsed == false)
        {
            // ���ݼ���״̬���Ƽ���״̬ mask ����ʾ������
            skillStatusMask.SetActive(false); // ������δʹ��ʱ��ʾ mask����������
        }
        if (skillStatusMask != null && physicsCheck.isDownGround || skillUsed == true)
        {
            // ���ݼ���״̬���Ƽ���״̬ mask ����ʾ������
            skillStatusMask.SetActive(true); // ������δʹ��ʱ��ʾ mask����������
        }


    }
    public void ResetSkill()
    {
        animator.SetBool("inskill", false);
    }
}

