using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedManager : MonoBehaviour
{
    private float gameTimer = 0f;
    private float stageDuration = 20f; // ÿ���׶ε�ʱ��������Ϊ��λ
    private int currentStage = 1;
    private bool stageCompleted = false;

    void Update()
    {
        // ������Ϸʱ��
        gameTimer += Time.deltaTime;

        // ���׶��Ƿ����
        if (!stageCompleted && gameTimer >= stageDuration * currentStage)
        {
            StageComplete();
        }
    }

    void StageComplete()
    {
        // �׶ν�����ִ�еĲ���
        // �����ٶ�
        Global.IncreaseSpeed(2); // ���� 2 ���ٶ�

        // ������һ���׶�
        currentStage++;
        // ���ý׶����״̬
        stageCompleted = false;
    }
}
