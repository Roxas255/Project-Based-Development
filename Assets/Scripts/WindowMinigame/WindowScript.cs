using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class WindowScript : MonoBehaviour
{
    public float timer = 60;
    public float currentTime;
    public Image timerFillImage;
    public static WindowScript instance;
    public bool gameStarted = false;
    public bool gameFinished = false;
    public void Start()
    {
        currentTime = timer;
        instance = this;
    }
    void Update()
    {
        //starts the game when you click and starts the timer
        if (Input.GetKeyDown(KeyCode.Mouse0) && !gameStarted)
        {
            gameStarted = true;
            //start timer
            StartCoroutine(Timer());
        }
        
        //updates the timer fill image to show how much time is left
        if (gameStarted)
        {
            float TimerPercent = Mathf.Clamp01(currentTime / timer);
            timerFillImage.fillAmount = TimerPercent;
        }

    }
    private IEnumerator Timer()
    {
        //this is temporary bc i need to transfer it to the window timer script.

        //timer thingy that decreases and finishes at 0
        while (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            yield return null;
        }
        /////////!!!////////////
        //i need to set up the finish panel that displayed your final score and stuff. 
        if (currentTime <= 0)
        {
            gameFinished = true;
            Debug.Log("Game finished");
        }   
    }
}
