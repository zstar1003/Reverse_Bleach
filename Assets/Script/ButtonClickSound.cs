using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonClickSound : MonoBehaviour
{
    public Button button; // 在 Inspector 界面中将按钮拖拽到此处

    public AudioSource audioSource; // 音频源
    public AudioClip clickSound; // 点击音效

    void Start()
    {
        // 获取按钮组件
        button = GetComponent<Button>();

        // 添加点击事件
        button.onClick.AddListener(PlayClickSound);
    }

    void PlayClickSound()
    {
        // 播放音效
        if (audioSource != null && clickSound != null)
        {
            audioSource.PlayOneShot(clickSound);
        }
    }
}
