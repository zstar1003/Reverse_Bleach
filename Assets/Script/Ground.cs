using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    private Rigidbody2D rigid2D;
    public bool move = false;

    private void Awake()
    {
        rigid2D = GetComponent<Rigidbody2D>();
    }

    public void ChangePos()
    {
        float startY;
        startY = Random.Range(0, 3);
        if (startY < 1)
        {
            startY = -4.5f;
        }
        else if (startY < 2)
        {
            startY = -2f;
        }
        else
            startY = 0.5f;
        Vector3 start = new Vector3(0, startY, 0);
        gameObject.transform.position = start;
        move = true;
    }
 
    private void FixedUpdate()
    {
        if (move == true)
            rigid2D.MovePosition(rigid2D.position + Vector2.left * Global.groundSpeed * Time.fixedDeltaTime);
    }
}
