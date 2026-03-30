using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PipeChecker : MonoBehaviour
{
    public Image[] tiles;
    public Sprite[] correctSprites;
    public Timer timer;

    public void CheckPuzzle()
    {
        if (tiles.Length != 24 || correctSprites.Length != 24)
        {
            Debug.LogError("You must assign exactly 24 tiles and 24 correct sprites.");
            return;
        }

        for (int i = 0; i < tiles.Length; i++)
        {
            if (tiles[i].sprite != correctSprites[i])
            {
                Debug.Log("Wrong path");
                return;
            }
        }

        Debug.Log("Correct path! +15 points");

        if (timer != null)
        {
            timer.StopTimer();
        }

        SceneManager.LoadScene("Level 1");
    }
}
