using UnityEngine;
using UnityEngine.SceneManagement;

public class Scoreboardbuttons : MonoBehaviour
{
    public void RetryLevel()
    {
        string lastLevel = PlayerPrefs.GetString("LastLevel", "Level 1");
        SceneManager.LoadScene(lastLevel);
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
