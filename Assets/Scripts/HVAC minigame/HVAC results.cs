using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Localization.Settings;

public class HVACresults : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private HVACminigame hvacMinigame;

    [Header("Result UI")]
    [SerializeField] private GameObject resultPanel;
    [SerializeField] private TMP_Text titleText;
    [SerializeField] private TMP_Text scoreText;

    [Header("Scene To Load")]
    [SerializeField] private string levelToLoad = "Level 2";

    private int pointsEarned = 0;

    void Start()
    {
        if (resultPanel != null)
        {
            resultPanel.SetActive(false);
        }
    }

    public void FinishHVAC()
    {
        bool isCorrect = hvacMinigame.IsComplete();
        GameManager.instance.HvacMinigameComplete = true;
        bool spanish = LocalizationSettings.SelectedLocale.Identifier.Code == "es";

        if (isCorrect)
        {
            pointsEarned = 5;

            titleText.text = spanish ? "HVAC completado" : "HVAC Complete";
            scoreText.text = spanish ? "Puntuaci�n de energ�a ganada: 5" : "Energy Score Gained: 5";
        }
        else
        {
            pointsEarned = 0;
            GameManager.instance.HVACWrong = true;
            titleText.text = spanish ? "Tarea fallida" : "Task Failed";
            scoreText.text = spanish ? "Puntuaci�n de energ�a ganada: 0" : "Energy Score Gained: 0";
        }


        PlayerPrefs.SetFloat("HVACScore2", pointsEarned);
        PlayerPrefs.Save();

        resultPanel.SetActive(true);
    }

    public void ContinueToLevel()
    {
        SceneManager.LoadScene(levelToLoad);
    }
}
