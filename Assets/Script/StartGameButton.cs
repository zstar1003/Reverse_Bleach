using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameButton : MonoBehaviour
{
    public void StartGame()
    {
        // ������������ڵ����ťʱ������
        SceneManager.LoadScene("SampleScene");
    }
}
