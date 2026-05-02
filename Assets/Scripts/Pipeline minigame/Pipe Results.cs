using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Localization.Settings; 

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

        // checks selected lnaguage
        string languageCode = LocalizationSettings.SelectedLocale.Identifier.Code;
        bool isSpanish = languageCode == "es";

        if (isCorrect)
        {
            pointsEarned = 15;

            if (isSpanish)
            {
                titleText.text = "Tubería completada";
                scoreText.text = "Puntuación de energía ganada: 15";
            }
            else
            {
                titleText.text = "Pipe Complete";
                scoreText.text = "Energy Score Gained: 15";
            }

            if (GameManager.instance != null)
            {
                GameManager.instance.PipeMinigameComplete = true;
            }
        }
        else
        {
            pointsEarned = 0;

            if (isSpanish)
            {
                titleText.text = "Tarea fallida";
                scoreText.text = "Puntuación de energía ganada: 0";
            }
            else
            {
                titleText.text = "Task Failed";
                scoreText.text = "Energy Score Gained: 0";
            }
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