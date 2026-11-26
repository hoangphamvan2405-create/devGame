using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    [SerializeField] private int startMag = 3;
    [SerializeField] private int startSheep = 20;
    [SerializeField] private TMP_Text scoreText;

    [SerializeField] private TMP_Text bulletText;
    [SerializeField] private  TMP_Text SheepText;
    [SerializeField] private int maxSheep = 50;
    [SerializeField] private int MaxMag = 20;
    
    private int score;
    private int Magazine;

    private int SheepCount;


    public int Score => score;
    public int Bullets => Magazine;

    public int Sheep => SheepCount;

    public bool IsGameOver => Magazine <= 0 || SheepCount <= 0;

    
    private void Awake()
    {
        Instance = this;
        Magazine = Mathf.Clamp(startMag, 0, MaxMag);
        SheepCount = Mathf.Clamp(startSheep, 0, maxSheep);
        updateUI();
    }

    public void AddSheep(int value)
    {
        if (IsGameOver || value <= 0) return;
        SheepCount += value;
        updateUI();
    }

    public void LoseSheep(int value)
    {
        if (IsGameOver || value <= 0) return;
        SheepCount -= value;
        updateUI();
        if (IsGameOver)
        {
            GameOver();
        }
    }

    public void AddScore(int value)
    {
        if (IsGameOver || value <= 0) return;
        score += value;
        updateUI();
    }

    public void LoseScore(int value)
    {
        if (IsGameOver || value <= 0) return;
        score -= value;
        updateUI();
    }

    public void LoseBullet()
    {
        if (IsGameOver) return;
        Magazine--;
        if (IsGameOver)
        {
            GameOver();
        }
        updateUI();
    }
    public void ExtraBullet()
    {
        if (IsGameOver || Magazine >= MaxMag) return;
        int amount = Random.Range(2, 7);
        Magazine = Mathf.Min(Magazine + amount, MaxMag);
        updateUI();
    }

    public void GameOver()
    {       
        Debug.Log("Game Over!" + " Score: " + score);
        PlayerPrefs.SetInt("FinalScore", score);
        PlayerPrefs.Save();
        SceneManager.LoadScene("EndScene");
    }

    private void updateUI()
    {
        if (scoreText != null)
        {
            scoreText.text = $"Score: {score}";
        }
        if (bulletText != null)
        {
            bulletText.text = $"{Magazine}/{MaxMag}";
        }
        if (SheepText != null)
        {
            SheepText.text = $"{SheepCount}";
        }
    }

    
}
