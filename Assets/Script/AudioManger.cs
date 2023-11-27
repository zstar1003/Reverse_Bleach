using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManger : MonoBehaviour
{
    public AudioClip[] musicTracks; // 存放音频曲目的数组
    private AudioSource audioSource;
    private int currentTrackIndex = 0; // 当前音频曲目索引

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        // 确保至少有一个音频曲目，并将其设置为 AudioSource 的初始曲目
        if (musicTracks.Length > 0)
        {
            audioSource.clip = musicTracks[currentTrackIndex];
            audioSource.Play(); // 播放当前音频曲目
        }
    }

    void Update()
    {
        // 检测按键输入来切换音频曲目
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            // 停止当前音频曲目
            audioSource.Stop();
            
            // 增加音频曲目索引，循环播放音频曲目
            currentTrackIndex = (currentTrackIndex + 1) % musicTracks.Length;

            // 将下一个音频曲目设置为 AudioSource 的当前曲目并播放它
            audioSource.clip = musicTracks[currentTrackIndex];
            audioSource.Play();
        }
    }
}
