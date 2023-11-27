using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; 

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; // 用于获取 GameManager 的实例
    private bool isGameOver = false; // 标记游戏是否已结束
    [SerializeField] private GameObject masks;
    [SerializeField] private Button menuButton;
    [SerializeField] private Button restartButton;
    [SerializeField] private Button quitButton;
    [SerializeField] private GameObject Timer;
    [SerializeField] private GameObject Skill;

    void Awake()
    {
        // 确保只有一个 GameManager 实例存在
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        masks.SetActive(false);

        menuButton.onClick.AddListener(OnMenuButtonClick);
        restartButton.onClick.AddListener(OnRestartButtonClick);
        quitButton.onClick.AddListener(OnQuitButtonClick);
    }


    private void OnMenuButtonClick()
    {
        SceneManager.LoadScene("Menu");
    }

    private void OnRestartButtonClick()
    {
        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1f; // 恢复游戏时间流逝
    }

    private void OnQuitButtonClick()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

    public void GameOver()
    {
        if (!isGameOver)
        {
            isGameOver = true;
            masks.SetActive(true);
            Timer.SetActive(false);
            Skill.SetActive(false);
            Time.timeScale = 0f; // 停止游戏时间流逝
        }
    }
}
