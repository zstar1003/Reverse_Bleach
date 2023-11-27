using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    public Text timerText; // 用于显示时间的 UI 文本

    private float gameTime = 0f; // 游戏时间

    void Update()
    {
        // 游戏时间增加
        gameTime += Time.deltaTime;

        // 将游戏时间转换为秒钟
        int seconds = Mathf.FloorToInt(gameTime);

        // 格式化时间文本
        string timeString = string.Format("{0}", seconds);

        // 更新 UI 文本显示游戏时间
        timerText.text = timeString;
    }

    // 获取当前游戏时间的方法
    public float GetGameTime()
    {
        return gameTime;
    }

}
