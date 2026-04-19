using UnityEngine;
using UnityEngine.UI;
public class StarDisplay : MonoBehaviour

{
    [Header("Stars")]
    public Image star1;
    public Image star2;
    public Image star3;

    public void SetStars(int score)
    {
        // Turn all off first
        star1.enabled = false;
        star2.enabled = false;
        star3.enabled = false;

        if (score >= 15 && score <= 29)
        {
            star1.enabled = true;
        }
        else if (score >= 30 && score <= 39)
        {
            star1.enabled = true;
            star2.enabled = true;
        }
        else if (score >= 40)
        {
            star1.enabled = true;
            star2.enabled = true;
            star3.enabled = true;
        }
    }
}
