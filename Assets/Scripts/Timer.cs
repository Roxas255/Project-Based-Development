using UnityEngine;
using UnityEngine.UI;
public class Timer : MonoBehaviour
{
    public Sprite[] frames;
    public Image image;

    public float timePerFrame = 10f; // 10 second duration

    private int currentFrame = 0;
    private float timer = 0f;

    void Start()
    {     // frame starts at 0
        if (frames.Length > 0)
        {
            image.sprite = frames[0];
        }
    }

    void Update()
    {   // tracks real time and will change frame after 10 seconds 
        timer += Time.deltaTime; 

        if (timer >= timePerFrame)
        {
            timer = 0f;
            currentFrame++;

            if (currentFrame < frames.Length)
            {
                image.sprite = frames[currentFrame];
            }
        }
    }
}
