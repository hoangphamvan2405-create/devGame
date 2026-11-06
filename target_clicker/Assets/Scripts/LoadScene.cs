using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public void LoadNextScene()
    {
        SceneManager.LoadScene(
            SceneManager.GetActiveScene().buildIndex + 1
        );
    }

    public void ReturnToSampleScene()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void ReturntoMainMenu()
    {
        SceneManager.LoadScene("StartScene");
    }

    public void startGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
