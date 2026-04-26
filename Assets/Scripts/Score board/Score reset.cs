using UnityEngine;

public class Scorereset : MonoBehaviour
{
    public static void ResetMiniGameScores()
    {
        // Scoreboard 1
        PlayerPrefs.SetFloat("WindowScore", 0f);
        PlayerPrefs.SetFloat("PipelineScore", 0f);
        PlayerPrefs.SetFloat("InsulationScore", 0f);

        // Scoreboard 2
        PlayerPrefs.SetFloat("PipelineScore2", 0f);
        PlayerPrefs.SetFloat("HVACScore2", 0f);

        PlayerPrefs.Save();
    }
}
