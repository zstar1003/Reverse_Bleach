using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedManager : MonoBehaviour
{
    private float gameTimer = 0f;
    private float stageDuration = 20f; // 每个阶段的时长，以秒为单位
    private int currentStage = 1;
    private bool stageCompleted = false;

    void Update()
    {
        // 更新游戏时间
        gameTimer += Time.deltaTime;

        // 检查阶段是否结束
        if (!stageCompleted && gameTimer >= stageDuration * currentStage)
        {
            StageComplete();
        }
    }

    void StageComplete()
    {
        // 阶段结束后执行的操作
        // 增加速度
        Global.IncreaseSpeed(2); // 增加 2 的速度

        // 进入下一个阶段
        currentStage++;
        // 重置阶段完成状态
        stageCompleted = false;
    }
}
