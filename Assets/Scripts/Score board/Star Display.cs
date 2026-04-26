using UnityEngine;
using UnityEngine.UI;
public class StarDisplay : MonoBehaviour

{
    [Header("Stars")]
    public Image star1;
    public Image star2;
    public Image star3;
    public GameObject stamp;
    public void SetStars(int score, int maxScore)
    {
        float percent = (float)score / maxScore;

        // Turn all off first
        star1.enabled = false;
        star2.enabled = false;
        star3.enabled = false;
        stamp.SetActive(false);

        if (percent >= 0.33f)
        {
            star1.enabled = true;
            stamp.SetActive(true);
        }

        if (percent >= 0.66f)
        {
            star2.enabled = true;
        }

        if (percent >= 0.9f)
        {
            star3.enabled = true;
        }
    }
}