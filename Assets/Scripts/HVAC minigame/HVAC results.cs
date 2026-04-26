using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

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

        if (isCorrect)
        {
            pointsEarned = 5;
            titleText.text = "HVAC Complete";
            scoreText.text = "Energy Score Gained: 5";
        }
        else
        {
            pointsEarned = 0;
            titleText.text = "Task Failed";
            scoreText.text = "Energy Score Gained: 0";
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
