using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PipeResults : MonoBehaviour
{
    [Header("Checker")]
    [SerializeField] private PipeChecker checker;

    [Header("Timer")]
    [SerializeField] private Timer timer;

    [Header("Result UI")]
    [SerializeField] private GameObject resultPanel;
    [SerializeField] private TMP_Text titleText;
    [SerializeField] private TMP_Text scoreText;

    [Header("Scene To Load")]
    [SerializeField] private string levelToLoad = "Level 1";

    [Header("Save Key")]
    [SerializeField] private string playerPrefsKey = "PipelineScore";

    private int pointsEarned = 0;

    void Start()
    {
        if (resultPanel != null)
        {
            resultPanel.SetActive(false);
        }
    }

    public void FinishPipeMinigame()
    {
        if (timer != null)
        {
            timer.StopTimer();
        }

        bool isCorrect = checker.IsPuzzleCorrect();

        if (isCorrect)
        {
            pointsEarned = 15;
            titleText.text = "Pipe Complete";
            scoreText.text = "Energy Score Gained: 15";

            if (GameManager.instance != null)
            {
                GameManager.instance.PipeMinigameComplete = true;
            }
        }
        else
        {
            pointsEarned = 0;
            titleText.text = "Task Failed";
            scoreText.text = "Energy Score Gained: 0";
        }

        PlayerPrefs.SetFloat(playerPrefsKey, pointsEarned);
        PlayerPrefs.Save();

        resultPanel.SetActive(true);
    }

    public void ContinueToLevel()
    {
        SceneManager.LoadScene(levelToLoad);
    }
}
