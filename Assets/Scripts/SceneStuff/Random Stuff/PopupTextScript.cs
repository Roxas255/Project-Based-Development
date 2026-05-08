using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PopupTextScript : MonoBehaviour
{
    public GameObject tutorialText;
    public GameObject ThermalText;
    public GameObject ThermalText2;

    public GameObject WindowHelpText1;
    public Animator HighlightButtonAnimator;
    public GameObject WindowQuestionPanel;
    public GameObject WindowInfoPanel;
    public TextMeshProUGUI WindowQuestionText;
    public TextMeshProUGUI InsulationQuestionText;
    public TextMeshProUGUI PipeQuestionText;
    public TextMeshProUGUI HVACQuestionText;

    public GameObject AfterWindowGamePopUp;
    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        if (currentScene.name == "Level1")
        {
            if (GameManager.instance.WindowMinigameComplete == false)
            {
                tutorialText.SetActive(true);
                Debug.Log("Hi");
            }
        }
    }
    void Update()
    {
        if (AfterWindowGamePopUp != null)
        {
            if (GameManager.instance.WindowMinigameComplete && !GameManager.instance.PipeMinigameComplete && !GameManager.instance.InsulationMinigameComplete)
            {
                AfterWindowGamePopUp.SetActive(true);
            }
        }
    }
    public void CheckIntroText()
    {
        if (GameManager.instance.playedIntro == false)
        {
            GameManager.instance.playedIntro = true;
            ThermalText.SetActive(true);
        }
    }
    public void CheckThermal1()
    {
        if (GameManager.instance.playedThermalIntro == false)
        {
            GameManager.instance.playedThermalIntro = true;
            ThermalText2.SetActive(true);
        }
    }
    public void CheckThermal2()
    {
        if (GameManager.instance.playedThermal2 == false && GameManager.instance.playedThermalIntro == true)
        {
            GameManager.instance.playedThermal2 = true;
            ThermalText2.SetActive(false);
        }
    }
    public void CheckWindowHelp()
    {
        if (GameManager.instance.playeedWindowHelp == false && GameManager.instance.playedThermal2 == true)
        {
            WindowHelpText1.SetActive(true);
            GameManager.instance.playeedWindowHelp = true;
            HighlightButtonAnimator.SetTrigger("Highlight2");
        }
    }
    public void CheckWindowHelp2()
    {
        if (GameManager.instance.playedWindowHelp2 == false)
        {
            GameManager.instance.playedWindowHelp2 = true;
            WindowHelpText1.SetActive(false);
            WindowInfoPanel.SetActive(true);
            WindowQuestionPanel.SetActive(true);
        }
    }
    public void QuestionWrong()
    {
        StartCoroutine(ChangeQuestionText("Incorrect. Try again."));
    }
    public IEnumerator ChangeQuestionText(string newText)
    {
        Debug.Log("ChangedText");
        WindowQuestionText.text = newText;
        yield return new WaitForSeconds(1.5f);
        WindowQuestionText.text = ("Where is the defect located?");
    }   
    public void QuestionWrong2()
    {
        StartCoroutine(ChangeQuestionText1("Incorrect. Try again."));
    }
    public IEnumerator ChangeQuestionText1(string newText)
    {
        Debug.Log("ChangedText");   
        InsulationQuestionText.text = newText;
        yield return new WaitForSeconds(1.5f);
        InsulationQuestionText.text = ("Where is the defect located?");
    }   
    public void PipeQuestionWrong()
    {
        StartCoroutine(ChangeQuestionText2("Incorrect. Try again."));
    }
    public IEnumerator ChangeQuestionText2(string newText)
    {        
        Debug.Log("ChangedText");
        PipeQuestionText.text = newText;
        yield return new WaitForSeconds(1.5f);
        PipeQuestionText.text = ("Where is the defect located?");
    }   
    public void QuestionWrong4()
    {
        StartCoroutine(ChangeQuestionText3("Incorrect. Try again."));
    }
    public IEnumerator ChangeQuestionText3(string newText)
    {
        Debug.Log("ChangedText");
        HVACQuestionText.text = newText;
        yield return new WaitForSeconds(1.5f);
        HVACQuestionText.text = ("Where is the defect located?");
    }   
}
