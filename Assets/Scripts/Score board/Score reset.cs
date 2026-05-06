using UnityEngine;

public class Scorereset : MonoBehaviour
{
    public static void ResetMiniGameScores()
    {
        // Level 1
        PlayerPrefs.SetFloat("WindowScore", 0f);
        PlayerPrefs.SetFloat("PipelineScore", 0f);
        PlayerPrefs.SetFloat("InsulationScore", 0f);

        // Level 2
        PlayerPrefs.SetFloat("Pipeline2Score", 0f);
        PlayerPrefs.SetFloat("HVACScore2", 0f);

        // Future Level 2 minigames
        PlayerPrefs.SetFloat("Window2Score", 0f);
        PlayerPrefs.SetFloat("Insulation2Score", 0f);

        PlayerPrefs.Save();
    }
}
