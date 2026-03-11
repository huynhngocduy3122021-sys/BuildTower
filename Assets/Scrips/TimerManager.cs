using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TimerManager : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public float timeLimit = 30f;
    public string loseSceneName = "Result 1";

    private float currentTime;
    public bool isGameOver = false;

    void Start()
    {
        currentTime = timeLimit;
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

    public void GameOver()
    {
        isGameOver = true;
        SceneManager.LoadScene(loseSceneName);
    }
}