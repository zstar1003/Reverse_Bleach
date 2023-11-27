using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1WithGravity : MonoBehaviour
{
    public Vector2 gravityDirection = Vector2.down; // 初始重力方向向下
    private Rigidbody2D rb;
    private GravityManager gravityManager;
    private bool hasCollided = false; // 添加一个变量来跟踪事件是否已触发过
    private PhysicsCheck physicsCheck;
    private Animator animator;
    public BoxCollider2D boxCollider;
    private GameObject player;
    private bool skillUsed = false; // 用于跟踪技能是否已经使用过
    public GameObject skillStatusMask; // 拖拽技能状态 mask 对象到此字段
    public AudioSource audioSource; // 在 Inspector 窗口中分配角色的 AudioSource 组件
    public AudioClip skillSound; // 在 Inspector 窗口中分配角色技能的音频剪辑




    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gravityManager = FindObjectOfType<GravityManager>(); // 获取场景中的 GravityManager
        physicsCheck = GetComponent<PhysicsCheck>();

        player = this.gameObject;

        // 将物体及其重力方向添加到管理器
        if (gravityManager != null)
        {
            gravityManager.AddObjectWithGravity(rb, gravityDirection);
        }
        // 获取 Animator 组件的引用
        animator = GetComponent<Animator>();
        // 在开始时获取 BoxCollider2D 组件的引用
        boxCollider = GetComponent<BoxCollider2D>();

    }

    void Update()
    {
        Vector2 center = transform.position; // 获取当前物体位置作为检测区域的中心点
        Vector2 size = new Vector2(1, 1); // 设置检测区域的尺寸

        Collider2D collider = Physics2D.OverlapBox(center, size, 0f); // 检测一个区域内是否有碰撞器

        if (!hasCollided) // 检查是否已经触发过碰撞事件
        {
            if (collider != null && collider.CompareTag("Player2"))
            {
                // 执行接触后的操作
                Vector3 currentScale = transform.localScale;
                currentScale.y *= -1; // 翻转y轴
                transform.localScale = currentScale;
                hasCollided = true;
            }
        }
        if (physicsCheck.isDownGround)
        {
            // 监听按键事件，例如按下F键（你也可以更改为其他按键）
            if (Input.GetKeyDown(KeyCode.F) && !skillUsed)
            {
                // 设置技能状态为已使用
                skillUsed = true;
                // 设置 Animator 中的 isSkill 参数为 true
                animator.SetBool("inskill", true);
                // 禁用 Rigidbody2D 组件
                rb.simulated = false;
                // 重新设置玩家位置
                player.transform.position = new Vector2(-5.03f, -1.04f);
                // 播放技能提示音效
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
            // 根据技能状态控制技能状态 mask 的显示与隐藏
            skillStatusMask.SetActive(false); // 当技能未使用时显示 mask，否则隐藏
        }
        if (skillStatusMask != null && physicsCheck.isUpGround || skillUsed == true)
        {
            // 根据技能状态控制技能状态 mask 的显示与隐藏
            skillStatusMask.SetActive(true); // 当技能未使用时显示 mask，否则隐藏
        }
    }

 

    public void ResetSkill()
    {
        animator.SetBool("inskill", false);
        rb.simulated = true;
        // 重新设置玩家位置
        player.transform.position = new Vector2(-7.93f, -3.41f);
    }

    public void MovePlayer()
    {
        // 重新设置玩家位置
        player.transform.position = new Vector2(-0.93f, -0.25f);
    }
}