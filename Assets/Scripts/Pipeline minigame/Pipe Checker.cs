using UnityEngine;
using UnityEngine.UI;

public class PipeChecker : MonoBehaviour
{
    public Image[] tiles;
    public Sprite[] correctSprites;

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
                string currentName = tiles[i].sprite != null ? tiles[i].sprite.name : "NULL";
                string correctName = correctSprites[i] != null ? correctSprites[i].name : "NULL";

                Debug.Log("Wrong path at index " + i +
                          " | Tile = " + tiles[i].gameObject.name +
                          " | Current = " + currentName +
                          " | Expected = " + correctName);
                return;
            }
        }

        Debug.Log("Correct path! +15 points");
    }
}
