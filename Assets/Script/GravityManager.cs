using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityManager : MonoBehaviour
{
    // 存储物体及其对应的重力方向
    private Dictionary<Rigidbody2D, Vector2> gravityDictionary = new Dictionary<Rigidbody2D, Vector2>();

    public GameObject Player1;
    private PhysicsCheck pyhsicsCheck_p1;

    void Start()
    {
        if (Player1 != null)
        {
            pyhsicsCheck_p1 = Player1.GetComponent<PhysicsCheck>();
        }
    }

    // 更新函数
    void Update()
    {
        // 只有当人物在地面上时才能操控重力
        if (pyhsicsCheck_p1.isDownGround || pyhsicsCheck_p1.isUpGround)
        {
            // 检测输入，例如按下特定按键来翻转重力
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Keypad0))
            {
                FlipGravityForSelectedObject();
            }
        }
    }

    // 添加物体到重力管理器
    public void AddObjectWithGravity(Rigidbody2D obj, Vector2 gravityDirection)
    {
        if (!gravityDictionary.ContainsKey(obj))
        {
            gravityDictionary[obj] = gravityDirection;
        }
    }

    // 翻转选定物体的重力方向
    void FlipGravityForSelectedObject()
    {
        List<Rigidbody2D> objectsToFlipGravity = new List<Rigidbody2D>();

        foreach (var obj in gravityDictionary.Keys)
        {
            // 在这里根据需要选择需要翻转重力的物体，并将其添加到临时列表
            if (obj.CompareTag("Player1") || obj.CompareTag("Player2"))
            {
                objectsToFlipGravity.Add(obj);
            }
        }

        // 循环结束后对临时列表中的物体进行重力翻转操作
        foreach (var obj in objectsToFlipGravity)
        {
            gravityDictionary[obj] = -gravityDictionary[obj];
            obj.gravityScale *= -1; // 如果使用 Rigidbody2D 的 gravityScale 属性来翻转重力方向
            //Physics2D.gravity = gravityDictionary[obj] * 9.81f; // 更新物理系统中的重力方向
        }
    }
}
