using UnityEngine;

public class WindowScript : MonoBehaviour
{
    public float timer = 60;
    public float currentTime;
    private static WindowScript instance;
    public bool gameStarted = false;
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
            //StartCoroutine(Timer());
        }
        
        //game logic
        while (gameStarted)
        {
            
        }

    }
    //IEnumerator Timer()
    //{
        //while (currentTime > 0)
        //{
      //      currentTime -= Time.deltaTime;
            //yield return null;
        //}
        //if (currentTime <= 0)
        //{
          //  Debug.Log("Game finished");
            ////game finished
        //}   
    //}
}
