using UnityEngine;
using UnityEngine.SceneManagement;

public class Level1Retry : MonoBehaviour
{
    public string targetScene = "Level 1";

    public void Retry()
    {
        Scorereset.ResetMiniGameScores(); 
        SceneManager.LoadScene(targetScene);
        GameManager.instance.ResetMinigameBools();
    }
}
