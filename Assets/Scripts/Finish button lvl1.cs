using UnityEngine;
using UnityEngine.SceneManagement;

public class Finishbuttonlvl1 : MonoBehaviour
{
    public void GoToScoreBoard()
    {
        // Save the level before leaving
        PlayerPrefs.SetString("LastLevel", SceneManager.GetActiveScene().name);

        // Load Score Board scene
        SceneManager.LoadScene("Score Board");
    }
}
