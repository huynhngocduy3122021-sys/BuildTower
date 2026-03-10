using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI questionText;
    public TextMeshProUGUI[] answerTexts;
    public Button[] answerButtons;
    public GameObject blockPrefab;
    public Transform spawnPoint;
    public TimerManager timerManager;

    public int maxWrongAttempts = 3;
    private int wrongAttempts = 0;
    public GameObject[] heartIcons;

    private int correctAnswer;
    private int currentOrder = 1;

    void Start()
    {
        SetupButtons();
        GenerateQuestion();
    }

    private void SetupButtons()
    {
        for (int i = 0; i < answerButtons.Length; i++)
        {
            int index = i;
            answerButtons[i].onClick.AddListener(() => CheckAnswer(index));
        }
    }

    public void GenerateQuestion()
    {
        int num1 = Random.Range(1, 10);
        int num2 = Random.Range(1, 10);
        correctAnswer = num1 + num2;

        questionText.text = num1 + " + " + num2 + " = ?";

        int correctIndex = Random.Range(0, 3);

        for (int i = 0; i < 3; i++)
        {
            if (i == correctIndex)
            {
                answerTexts[i].text = correctAnswer.ToString();
            }
            else
            {
                int wrongAnswer = correctAnswer;
                while (wrongAnswer == correctAnswer)
                {
                    wrongAnswer = Random.Range(2, 20);
                }
                answerTexts[i].text = wrongAnswer.ToString();
            }
        }
    }

    public void CheckAnswer(int buttonIndex)
    {
        if (timerManager.isGameOver) return;

        int selectedAnswer = int.Parse(answerTexts[buttonIndex].text);

        if (selectedAnswer == correctAnswer)
        {
            Sprite buttonSprite = answerButtons[buttonIndex].GetComponent<Image>().sprite;
            DropBlock(selectedAnswer, buttonSprite);
            
            GenerateQuestion();
        }
        else
        {
            HandleWrongAnswer();
        }
    }

    private void DropBlock(int answerValue, Sprite blockSprite)
    {
        GameObject newBlock = Instantiate(blockPrefab, spawnPoint.position, Quaternion.identity);
        
        SpriteRenderer sr = newBlock.GetComponent<SpriteRenderer>();
        if (sr != null)
        {
            sr.sprite = blockSprite;
            sr.sortingOrder = currentOrder++;
        }

        TextMeshPro textComponent = newBlock.GetComponentInChildren<TextMeshPro>();
        if (textComponent != null)
        {
            textComponent.text = answerValue.ToString();
        }
    }

    private void HandleWrongAnswer()
    {
        if (wrongAttempts < heartIcons.Length)
        {
            heartIcons[heartIcons.Length - 1 - wrongAttempts].SetActive(false);
        }

        wrongAttempts++;
        
        if (wrongAttempts >= maxWrongAttempts)
        {
            timerManager.GameOver();
        }
    }
}