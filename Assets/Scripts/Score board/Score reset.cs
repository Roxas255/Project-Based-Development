using UnityEngine;

public class Scorereset : MonoBehaviour
{
    public static void ResetMiniGameScores()
    {
        PlayerPrefs.SetFloat("WindowScore", 0f);
        PlayerPrefs.SetFloat("PipelineScore", 0f);
        PlayerPrefs.SetFloat("InsulationScore", 0f);
        PlayerPrefs.Save();
    }
}
