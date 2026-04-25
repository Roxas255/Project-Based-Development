using UnityEngine;
using UnityEngine.SceneManagement;

public class Level2Retry : MonoBehaviour
{
    public string targetScene = "Level 2";

    public void Retry()
    {
        Scorereset.ResetMiniGameScores();
        SceneManager.LoadScene(targetScene);
    }
}
