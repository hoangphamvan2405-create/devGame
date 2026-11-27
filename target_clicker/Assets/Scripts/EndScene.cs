using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScene : MonoBehaviour
{
    [SerializeField] private TMP_Text finalScoreText;
    [SerializeField] private TMP_Text highScoreText;


    private void Start()
    {
        int finalScore = PlayerPrefs.GetInt("FinalScore", 0);
        int highScore = PlayerPrefs.GetInt("HighScore", 0);

        if (finalScore > highScore)
        {
            highScore = finalScore;
            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save();
        }

        highScoreText.text = $"Điểm cao nhất: {highScore}";
        finalScoreText.text = $"{finalScore}";
    }

    public void ReplayGame()
    {
        string replayScene = PlayerPrefs.GetString("ReplayScene", "SampleScene");
        SceneManager.LoadScene(replayScene);
    }

    public void ReturntoMainMenu()
    {
        SceneManager.LoadScene("StartScene");
    }
}
