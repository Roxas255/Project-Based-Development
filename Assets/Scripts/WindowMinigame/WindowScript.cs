using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WindowScript : MonoBehaviour
{
    public float timer = 60;
    public float currentTime;
    public Image timerFillImage;
    public static WindowScript instance;
    public bool gameStarted = false;
    public bool gameFinished = false;

    public GameObject finishButton;
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
        Scene currentScene = SceneManager.GetActiveScene();

        //timer thingy that decreases and finishes at 0
        while (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            yield return null;
        }
        if (currentTime <= 0)
        {
            FinishMinigame();
        }   
    }
    public void FinishMinigame()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        gameFinished = true;
            if ((currentScene.name == "Window1") || currentScene.name == "Window2")
            {
                GameManager.instance.WindowMinigameComplete = true;
                GameManager.instance.windowScore = WindowLogic.instance.FinalScore;
                finishButton.SetActive(true);
                WindowLogic.instance.finalscore.text = ("Accuracy: " + WindowLogic.instance.FinalScore.ToString("F2") + "%");

            }
            if ((currentScene.name == "Insulation1") || currentScene.name == "Insulation2")
            {
                GameManager.instance.InsulationMinigameComplete = true;
                GameManager.instance.insulationScore = WindowLogic.instance.FinalScore;
                finishButton.SetActive(true);
                WindowLogic.instance.finalscore.text = ("Accuracy: " + WindowLogic.instance.FinalScore.ToString("F2") + "%");
            }
            //actually i dont think we need this but im keeping this here bc i might forget
            if ((currentScene.name == "Pipe1") || currentScene.name == "Pipe 2")
            {
                GameManager.instance.PipeMinigameComplete = true;
                //we have to make a scoring thing for the pipe minigame. 
                // GameManager.instance.pipeScore = PipeLogic?.instance.FinalScore;
                //finishButton.SetActive(true);
            }
            if (currentScene.name == "HVAC minigame")
            {
                GameManager.instance.HvacMinigameComplete = true;
            }
            Debug.Log("Game finished");
    }
}
