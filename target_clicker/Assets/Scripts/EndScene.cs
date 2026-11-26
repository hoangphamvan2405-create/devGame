using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScene : MonoBehaviour
{
    [SerializeField] private TMP_Text finalScoreText;
    [SerializeField] private TMP_Text highScoreText;


    private void Start()
    {
        int highScore = PlayerPrefs.GetInt("HighScore", 0);
        highScoreText.text = $"Điểm cao nhất: {highScore}";

        int finalScore = PlayerPrefs.GetInt("FinalScore", 0);
        finalScoreText.text = $"{finalScore}";
    }

    public void ReturntoMainMenu()
    {
        SceneManager.LoadScene("StartScene");
    }
}
