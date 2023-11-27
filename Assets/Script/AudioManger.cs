using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManger : MonoBehaviour
{
    public AudioClip[] musicTracks; // �����Ƶ��Ŀ������
    private AudioSource audioSource;
    private int currentTrackIndex = 0; // ��ǰ��Ƶ��Ŀ����

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        // ȷ��������һ����Ƶ��Ŀ������������Ϊ AudioSource �ĳ�ʼ��Ŀ
        if (musicTracks.Length > 0)
        {
            audioSource.clip = musicTracks[currentTrackIndex];
            audioSource.Play(); // ���ŵ�ǰ��Ƶ��Ŀ
        }
    }

    void Update()
    {
        // ��ⰴ���������л���Ƶ��Ŀ
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            // ֹͣ��ǰ��Ƶ��Ŀ
            audioSource.Stop();
            
            // ������Ƶ��Ŀ������ѭ��������Ƶ��Ŀ
            currentTrackIndex = (currentTrackIndex + 1) % musicTracks.Length;

            // ����һ����Ƶ��Ŀ����Ϊ AudioSource �ĵ�ǰ��Ŀ��������
            audioSource.clip = musicTracks[currentTrackIndex];
            audioSource.Play();
        }
    }
}
