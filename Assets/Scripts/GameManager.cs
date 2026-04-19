using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool WindowMinigameComplete = false;
    public bool InsulationMinigameComplete = false;
    public bool PipeMinigameComplete = false;

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
            CheckMinigamesComplete();
        }
    }

    void CheckDialoguePlayed()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        
    }

    void CheckMinigamesComplete()
    {
        if (WindowMinigameComplete == true)
        {
            
        }
        if (InsulationMinigameComplete == true)
        {
            
        }
        if (PipeMinigameComplete == true)
        {
            
        }
    }
}
