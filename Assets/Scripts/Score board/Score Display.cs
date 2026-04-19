using TMPro;
using UnityEngine;

public class ScoreDisplay : MonoBehaviour
{
    [Header("Main Score")]
    [SerializeField] private TMP_Text currentScoreText;
    [SerializeField] private TMP_Text bestScoreText;

    [Header("Mini Game Scores")]
    [SerializeField] private TMP_Text windowScoreText;
    [SerializeField] private TMP_Text pipelineScoreText;
    [SerializeField] private TMP_Text insulationScoreText;
    [SerializeField] private TMP_Text gradeText;
    public StarDisplay starDisplay;
    void Start()
    {
        float windowScore = PlayerPrefs.GetFloat("WindowScore", 0f);
        float pipelineScore = PlayerPrefs.GetFloat("PipelineScore", 0f);
        float insulationScore = PlayerPrefs.GetFloat("InsulationScore", 0f);

        float currentScore = windowScore + pipelineScore + insulationScore;

        starDisplay.SetStars((int)currentScore);

        float bestScore = PlayerPrefs.GetFloat("BestEnergyAuditScore", 0f);

        gradeText.text = GetGrade((int)currentScore);

        if (currentScore > bestScore)
        {
            bestScore = currentScore;
            PlayerPrefs.SetFloat("BestEnergyAuditScore", bestScore);
            PlayerPrefs.Save();
        }

        currentScoreText.text = currentScore.ToString("F0");
        bestScoreText.text = bestScore.ToString("F0");

        windowScoreText.text = windowScore.ToString("F0");
        pipelineScoreText.text = pipelineScore.ToString("F0");
        insulationScoreText.text = insulationScore.ToString("F0");
    }
    string GetGrade(int score)
    {
        if (score >= 40) return "A";
        if (score >= 30) return "B";
        if (score >= 15) return "C";
        return "F";
    }
}
