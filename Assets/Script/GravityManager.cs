using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityManager : MonoBehaviour
{
    // �洢���弰���Ӧ����������
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

    // ���º���
    void Update()
    {
        // ֻ�е������ڵ�����ʱ���ܲٿ�����
        if (pyhsicsCheck_p1.isDownGround || pyhsicsCheck_p1.isUpGround)
        {
            // ������룬���簴���ض���������ת����
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Keypad0))
            {
                FlipGravityForSelectedObject();
            }
        }
    }

    // ������嵽����������
    public void AddObjectWithGravity(Rigidbody2D obj, Vector2 gravityDirection)
    {
        if (!gravityDictionary.ContainsKey(obj))
        {
            gravityDictionary[obj] = gravityDirection;
        }
    }

    // ��תѡ���������������
    void FlipGravityForSelectedObject()
    {
        List<Rigidbody2D> objectsToFlipGravity = new List<Rigidbody2D>();

        foreach (var obj in gravityDictionary.Keys)
        {
            // �����������Ҫѡ����Ҫ��ת���������壬��������ӵ���ʱ�б�
            if (obj.CompareTag("Player1") || obj.CompareTag("Player2"))
            {
                objectsToFlipGravity.Add(obj);
            }
        }

        // ѭ�����������ʱ�б��е��������������ת����
        foreach (var obj in objectsToFlipGravity)
        {
            gravityDictionary[obj] = -gravityDictionary[obj];
            obj.gravityScale *= -1; // ���ʹ�� Rigidbody2D �� gravityScale ��������ת��������
            //Physics2D.gravity = gravityDictionary[obj] * 9.81f; // ��������ϵͳ�е���������
        }
    }
}
