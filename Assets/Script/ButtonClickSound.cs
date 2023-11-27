using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonClickSound : MonoBehaviour
{
    public Button button; // �� Inspector �����н���ť��ק���˴�

    public AudioSource audioSource; // ��ƵԴ
    public AudioClip clickSound; // �����Ч

    void Start()
    {
        // ��ȡ��ť���
        button = GetComponent<Button>();

        // ��ӵ���¼�
        button.onClick.AddListener(PlayClickSound);
    }

    void PlayClickSound()
    {
        // ������Ч
        if (audioSource != null && clickSound != null)
        {
            audioSource.PlayOneShot(clickSound);
        }
    }
}
