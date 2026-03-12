using System.Collections;
using UnityEngine;

public class WindowScript : MonoBehaviour
{
    public float timer = 60;
    public float currentTime;
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
