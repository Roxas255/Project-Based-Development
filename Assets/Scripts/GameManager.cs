using System.Collections;
using NUnit.Framework;
using TMPro;
using UnityEditor.PackageManager.UI;
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
    
    
    //btu stuff
    public int CurrentBTU = 90000;
    public bool windowAbove97;
    public bool windowAbove90;
    public bool InsulationAbove97;
    public bool InsulationAbove90;
    public bool PipeCorrect;
    public bool PipeWrong;
    public bool HVACcorrect;
    public bool HVACWrong;




    public bool playedIntro = false;
    public bool playedThermalIntro = false;
    public bool playedThermal2 = false;
    public bool playeedWindowHelp = false;
    public bool playedWindowHelp2 = false;

    public bool checked1;
    public bool checked2;
    public bool checked3;
    public bool checked4;


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
    

    public void Update()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        if (!checked1)
            CheckWindowScore();
        if (!checked2)
            CheckInsulationScore();
        if (!checked3)
            CheckPipeScore();
        if (!checked4)
            CheckHVACScore();
    }


    public void CheckWindowScore()
    {        
        Scene currentScene = SceneManager.GetActiveScene();

        if (windowAbove97)
        {
            CurrentBTU -= 8000;
            checked1 = true;
        }
        else if (windowAbove90)     
        {
            CurrentBTU -= 6000;
            checked1 = true;
        }
        else if (!windowAbove90 && !windowAbove97)
            CurrentBTU -= 0;
    }

    public void CheckInsulationScore()
    {        
        Scene currentScene = SceneManager.GetActiveScene();

        if (InsulationAbove97)
        {
           CurrentBTU -= 14000;
           checked2 = true;
        }
        else if (InsulationAbove90)
        {
            CurrentBTU -= 12000;
            checked2 = true;
        }
        else if (!InsulationAbove97 && !InsulationAbove90)
            CurrentBTU -= 0;
    }
    
    public void CheckPipeScore()
    {        
        Scene currentScene = SceneManager.GetActiveScene();

        if (PipeCorrect)
        {
            CurrentBTU -= 4000;
            checked3 = true;
        }
        else if (PipeWrong)
        {
            CurrentBTU += 2000;
            checked3 = true;
        }
    }
    public void CheckHVACScore()
    {        
        Scene currentScene = SceneManager.GetActiveScene();

        if (HVACcorrect)
        {
            Debug.Log("-6000");
            CurrentBTU -= 6000;
            checked4 = true;
        }
        else if (HVACWrong)
        {
            CurrentBTU += 2000;
            checked4 = true;
        }
    }

    public IEnumerator HvacWrongCheckOnOff()
    {
        yield return new WaitForSeconds(1f);
        Debug.Log("Check4 false ");
        checked4 = false;
        HVACWrong = false;
        Debug.Log("True");
        Level2Popups.instance.HVACbutton.SetActive(true);
        Debug.Log("DONE");
    }

    public IEnumerator PipeWrongCheckOnOff()
    {
        yield return new WaitForSeconds(1f);
        checked3 = false;
        PipeWrong = false;
    }

        
    public void ResetMinigameBools()
    {
        // Reset BTU
        CurrentBTU = 90000;
        // Minigame Complete Checks
        WindowMinigameComplete = false; 
        InsulationMinigameComplete = false; 
        PipeMinigameComplete = false; 
        HvacMinigameComplete = false; 

        // Score thresholds
        windowAbove97 = false;
        windowAbove90 = false;
        InsulationAbove97 = false;
        InsulationAbove90 = false;

        // Results
        PipeCorrect = false;
        HVACcorrect = false;

        PipeWrong = false;
        HVACWrong = false;

        // Progression checks
        checked1 = false;
        checked2 = false;
        checked3 = false;
        checked4 = false;
    }


}
