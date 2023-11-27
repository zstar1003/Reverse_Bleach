using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsCheck : MonoBehaviour
{
    public float checkRaduis;
    public LayerMask downgroundLayer;
    public LayerMask upgroundLayer;
    public bool isDownGround;
    public bool isUpGround;

    void Update()
    {
        Check();
    }
    public void Check()
    {
        isDownGround = Physics2D.OverlapCircle(transform.position, checkRaduis, downgroundLayer);
        isUpGround = Physics2D.OverlapCircle(transform.position, checkRaduis, upgroundLayer);
    }
}
