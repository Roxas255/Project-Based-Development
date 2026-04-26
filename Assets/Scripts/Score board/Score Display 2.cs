using TMPro;
using UnityEngine;

public class ScoreDisplay2 : MonoBehaviour
{
    [Header("Main Score")]
    [SerializeField] private TMP_Text currentScoreText;
    [SerializeField] private TMP_Text bestScoreText;

    [Header("Mini Game Scores")]
    [SerializeField] private TMP_Text hvacScoreText;
    [SerializeField] private TMP_Text pipeline2ScoreText;
    [SerializeField] private TMP_Text gradeText;

    public StarDisplay starDisplay;
    public Scorepointer2 scorePointerMover;

    void Start()
    {
        float hvacScore = PlayerPrefs.GetInt("HVACScore", 0);
        float pipeline2Score = PlayerPrefs.GetFloat("Pipeline2Score", 0f);

        float currentScore = hvacScore + pipeline2Score;
        currentScore = Mathf.Clamp(currentScore, 0f, 50f);

        float bestScore = PlayerPrefs.GetFloat("BestEnergyAuditScore_Level2", 0f);

        // reset impossible scores
        if (bestScore > 50f)
        {
            bestScore = 0f;
            PlayerPrefs.SetFloat("BestEnergyAuditScore_Level2", bestScore);
            PlayerPrefs.Save();
        }

        if (currentScore > bestScore)
        {
            bestScore = currentScore;
            PlayerPrefs.SetFloat("BestEnergyAuditScore_Level2", bestScore);
            PlayerPrefs.Save();
        }

        currentScoreText.text = currentScore.ToString("F0");
        bestScoreText.text = bestScore.ToString("F0");

        hvacScoreText.text = hvacScore.ToString("F0");
        pipeline2ScoreText.text = pipeline2Score.ToString("F0");

        gradeText.text = GetGrade((int)currentScore);

        starDisplay.SetStars((int)currentScore, 50);
        scorePointerMover.MovePointer(currentScore);
    }

    string GetGrade(int score)
    {
        if (score >= 45) return "A";
        if (score >= 35) return "B";
        if (score >= 20) return "C";
        return "F";
    }
}