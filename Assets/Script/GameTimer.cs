using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    public Text timerText; // ������ʾʱ��� UI �ı�

    private float gameTime = 0f; // ��Ϸʱ��

    void Update()
    {
        // ��Ϸʱ������
        gameTime += Time.deltaTime;

        // ����Ϸʱ��ת��Ϊ����
        int seconds = Mathf.FloorToInt(gameTime);

        // ��ʽ��ʱ���ı�
        string timeString = string.Format("{0}", seconds);

        // ���� UI �ı���ʾ��Ϸʱ��
        timerText.text = timeString;
    }

    // ��ȡ��ǰ��Ϸʱ��ķ���
    public float GetGameTime()
    {
        return gameTime;
    }

}
