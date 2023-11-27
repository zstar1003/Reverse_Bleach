using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameButton : MonoBehaviour
{
    public void StartGame()
    {
        // 这个方法将会在点击按钮时被调用
        SceneManager.LoadScene("SampleScene");
    }
}
