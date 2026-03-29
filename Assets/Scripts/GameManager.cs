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
