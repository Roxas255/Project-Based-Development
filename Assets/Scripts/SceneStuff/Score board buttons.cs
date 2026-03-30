using UnityEngine;
using UnityEngine.SceneManagement;

public class Scoreboardbuttons : MonoBehaviour
{
    public void RetryLevel()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
