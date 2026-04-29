using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool WindowMinigameComplete = false;
    public bool InsulationMinigameComplete = false;
    public bool PipeMinigameComplete = false;
    public bool HvacMinigameComplete = false;
    public float totalScore;
    public float windowScore;
    public float insulationScore;
    public float pipeScore;



    public bool playedIntro = false;
    public bool playedThermalIntro = false;
    public bool playedThermal2 = false;
    public bool playeedWindowHelp = false;
    public bool playedWindowHelp2 = false;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        
    }
    void Update()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        if (currentScene.name == "Level1")
        {
            //ResetMinigameBools();
        }
    }

    void CheckDialoguePlayed()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        
    }

    public void ResetMinigameBools()
    {
        WindowMinigameComplete = false;
        InsulationMinigameComplete = false;
        PipeMinigameComplete = false;
        HvacMinigameComplete = false;
    }
}
