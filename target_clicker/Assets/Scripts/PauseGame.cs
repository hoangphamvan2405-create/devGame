using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{
    public static bool IsPaused { get; private set; }

    [SerializeField] private GameObject panel;
    [SerializeField] private TMP_Text highScoreText;
    [SerializeField] private GameObject volumeOnSprite;
    [SerializeField] private GameObject volumeOffSprite;
    private bool isVolumeOn = true;
    public void ToggleVolume()
    {
        isVolumeOn = !isVolumeOn;
        AudioListener.volume = isVolumeOn ? 1f : 0f;
        volumeOnSprite.SetActive(isVolumeOn);
        volumeOffSprite.SetActive(!isVolumeOn);
    }

    public void Start()
    {
        IsPaused = false;
        Time.timeScale = 1f;

        volumeOnSprite.SetActive(isVolumeOn);
        volumeOffSprite.SetActive(!isVolumeOn);
        AudioListener.volume = isVolumeOn ? 1f : 0f;

        if (highScoreText != null)
        {
            int highScore = PlayerPrefs.GetInt("HighScore", 0);
            highScoreText.text = $"RECORD: {highScore}";
        }
    }   
    
    public void Pause()
    {
        IsPaused = true;
        panel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
        IsPaused = false;
        panel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void StartGame()
    {
        IsPaused = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene("StartScene");
    }
}
