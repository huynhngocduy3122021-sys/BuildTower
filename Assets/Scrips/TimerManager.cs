using UnityEngine;
using TMPro;

public class TimerManager : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public float timeLimit = 10f;
    public GameObject gameOverPanel;

    private float currentTime;
    public bool isGameOver = false;

    void Start()
    {
        currentTime = timeLimit;
        if (gameOverPanel != null) gameOverPanel.SetActive(false);
        Time.timeScale = 1;
    }

    void Update()
    {
        if (isGameOver) return;

        currentTime -= Time.deltaTime;
        
        if (timerText != null)
        {
            timerText.text = Mathf.CeilToInt(currentTime).ToString();
        }

        if (currentTime <= 0)
        {
            GameOver();
        }
    }

    public void ResetTimer()
    {
        currentTime = timeLimit;
    }

    public void GameOver()
    {
        isGameOver = true;
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }
        Time.timeScale = 0;
    }
}