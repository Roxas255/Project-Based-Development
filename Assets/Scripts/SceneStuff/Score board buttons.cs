using UnityEngine;
using UnityEngine.SceneManagement;

public class Scoreboardbuttons : MonoBehaviour
{
    public void RetryLevel()
    {
        // Reload the current level
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
