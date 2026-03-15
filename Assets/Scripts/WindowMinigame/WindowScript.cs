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
        if (Input.GetKeyDown(KeyCode.Mouse0) && !gameStarted)
        {
            gameStarted = true;
            //start timer
            StartCoroutine(Timer());
        }
        
        //game logic
        if (gameStarted)
        {
            float TimerPercent = Mathf.Clamp01(currentTime / timer);
            timerFillImage.fillAmount = TimerPercent;
        }

    }
    private IEnumerator Timer()
    {
        while (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            yield return null;
        }
        if (currentTime <= 0)
        {
            gameFinished = true;
            Debug.Log("Game finished");
        }   
    }
}
