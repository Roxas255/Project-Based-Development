using UnityEngine;
using UnityEngine.SceneManagement;

public class Scoreboardbuttons : MonoBehaviour
{
    public void RetryLevel()
    {
        // Reload the current level
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    // Go back to Main Menu
    public void GoToMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
