using TMPro;
using UnityEngine;

public class ScoreDisplay2 : MonoBehaviour
{
    [Header("Main Score")]
    [SerializeField] private TMP_Text currentScoreText;
    [SerializeField] private TMP_Text bestScoreText;

    [Header("Mini Game Scores")]
    [SerializeField] private TMP_Text window2ScoreText;
    [SerializeField] private TMP_Text pipeline2ScoreText;
    [SerializeField] private TMP_Text insulation2ScoreText;
    [SerializeField] private TMP_Text hvacScoreText;
    [SerializeField] private TMP_Text gradeText;

    public StarDisplay starDisplay;
    public Scorepointer2 scorePointerMover;

    void Start()
    {
        float windowScore = PlayerPrefs.GetFloat("Window2Score", 0f);
        float pipelineScore = PlayerPrefs.GetFloat("Pipeline2Score", 0f);
        float insulationScore = PlayerPrefs.GetFloat("Insulation2Score", 0f);
        float hvacScore = PlayerPrefs.GetFloat("HVACScore2", 0f);

        float currentScore = windowScore + pipelineScore + insulationScore + hvacScore;
        currentScore = Mathf.Clamp(currentScore, 0f, 50f);

        float bestScore = PlayerPrefs.GetFloat("BestEnergyAuditScore_Level2", 0f);

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

        window2ScoreText.text = windowScore.ToString("F0");
        pipeline2ScoreText.text = pipelineScore.ToString("F0");
        insulation2ScoreText.text = insulationScore.ToString("F0");
        hvacScoreText.text = hvacScore.ToString("F0");

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