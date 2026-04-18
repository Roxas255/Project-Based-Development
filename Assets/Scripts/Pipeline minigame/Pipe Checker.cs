using UnityEngine;
using UnityEngine.UI;

public class PipeChecker : MonoBehaviour
{
    public Image[] tiles;
    public Sprite[] correctSprites;

    public bool IsPuzzleCorrect()
    {
        if (tiles.Length != 24 || correctSprites.Length != 24)
        {
            Debug.LogError("You must assign exactly 24 tiles and 24 correct sprites.");
            return false;
        }

        for (int i = 0; i < tiles.Length; i++)
        {
            if (tiles[i].sprite != correctSprites[i])
            {
                Debug.Log("Wrong path");
                return false;
            }
        }

        Debug.Log("Correct path!");
        return true;
    }
}