using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public Sprite[] frames;
    public Image image;

    public float timePerFrame = 6f;
    public float maxTime = 60f;

    private int currentFrame = 0;
    private float frameTimer = 0f;
    private float totalTimer = 0f;

    private bool timerStopped = false;

    void Start()
    {
        if (frames.Length > 0 && image != null)
        {
            image.sprite = frames[0];
        }
    }

    void Update()
    {
        if (timerStopped)
            return;

        totalTimer += Time.deltaTime;
        frameTimer += Time.deltaTime;

        // Change clock frame every 10 seconds
        if (frameTimer >= timePerFrame)
        {
            frameTimer = 0f;
            currentFrame++;

            if (currentFrame < frames.Length)
            {
                image.sprite = frames[currentFrame];
            }
        }

        // Fail after 60 seconds
        if (totalTimer >= maxTime)
        {
            Debug.Log("Time Up! Minigame failed.");
            SceneManager.LoadScene("Level 1");
        }
    }

    public void StopTimer()
    {
        timerStopped = true;
    }
}