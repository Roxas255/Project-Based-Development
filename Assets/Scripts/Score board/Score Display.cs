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

    void Start()
    {
        // Get saved minigame scores
        float windowScore = PlayerPrefs.GetFloat("WindowScore", 0f);
        float pipelineScore = PlayerPrefs.GetFloat("PipelineScore", 0f);
        float insulationScore = PlayerPrefs.GetFloat("InsulationScore", 0f);

        // Add them together for current score
        float currentScore = windowScore + pipelineScore + insulationScore;

        // Get best score
        float bestScore = PlayerPrefs.GetFloat("BestEnergyAuditScore", 0f);

        // If current score is better, save it
        if (currentScore > bestScore)
        {
            bestScore = currentScore;
            PlayerPrefs.SetFloat("BestEnergyAuditScore", bestScore);
            PlayerPrefs.Save();
        }

        // Display main score
        currentScoreText.text = currentScore.ToString("F0");
        bestScoreText.text = bestScore.ToString("F0");

        // Display each minigame score
        windowScoreText.text = "Window.................... " + windowScore.ToString("F0");
        pipelineScoreText.text = "Pipeline.................. " + pipelineScore.ToString("F0");
        insulationScoreText.text = "Insulation............... " + insulationScore.ToString("F0");
    }
}
