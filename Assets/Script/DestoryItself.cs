using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryItself : MonoBehaviour
{
    void Update()
    {
        // 如果地图块移出屏幕外，则销毁它
        if (transform.position.x < -20f) // 这里的 -20f 是一个举例，根据你的场景尺寸进行调整
        {
            Destroy(gameObject);
        }
    }
}
