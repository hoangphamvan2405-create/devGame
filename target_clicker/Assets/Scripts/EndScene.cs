using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScene : MonoBehaviour
{
    [SerializeField] private TMP_Text finalScoreText;

    private void Start()
    {
        if (finalScoreText == null)
        {
            Debug.LogError("Final Score Text is not assigned.", this);
            return;
        }

        int finalScore = PlayerPrefs.GetInt("FinalScore", 0);
        finalScoreText.text = $"Tổng điểm: {finalScore}";
    }

    public void ReturntoMainMenu()
    {
        SceneManager.LoadScene("StartScene");
    }
}
