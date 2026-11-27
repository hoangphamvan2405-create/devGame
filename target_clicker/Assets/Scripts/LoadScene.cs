using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    [SerializeField] private GameObject Mode;
    [SerializeField] private GameObject Tutorial;

    private bool clicked = true;
    private bool Choose = true;
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

    public void chooseMode()
    {
        Choose = true;
        Mode.SetActive(true);
    }

    public void Hardgame()
    {
        SceneManager.LoadScene("HardScene");
    }

    public void ChooseTutorial()
    {
        clicked = true;
        Tutorial.SetActive(true);
    }

    public void OutPanel()
    {
        clicked = false;
        Tutorial.SetActive(false);
    }
}
