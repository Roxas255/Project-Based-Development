using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Localization.Settings;

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
        if (LocalizationSettings.SelectedLocale.Identifier.Code == "es")
        {
            StartCoroutine(ChangeQuestionText("Incorrecto. Inténtalo de nuevo."));
        }
        else
        {
            StartCoroutine(ChangeQuestionText("Incorrect. Try again."));
        }
    }
    public IEnumerator ChangeQuestionText(string newText)
    {
        Debug.Log("ChangedText");
        WindowQuestionText.text = newText;
        yield return new WaitForSeconds(1.5f);
        if (LocalizationSettings.SelectedLocale.Identifier.Code == "es")
        {
            WindowQuestionText.text = "¿Dónde está ubicado el defecto?";
        }
        else
        {
            WindowQuestionText.text = "Where is the defect located?";
        }
    }
    public void QuestionWrong2()
    {
        if (LocalizationSettings.SelectedLocale.Identifier.Code == "es")
        {
            StartCoroutine(ChangeQuestionText1("Incorrecto. Inténtalo de nuevo."));
        }
        else
        {
            StartCoroutine(ChangeQuestionText1("Incorrect. Try again."));
        }
    }
    public IEnumerator ChangeQuestionText1(string newText)
    {
        Debug.Log("ChangedText");   
        InsulationQuestionText.text = newText;
        yield return new WaitForSeconds(1.5f);
        if (LocalizationSettings.SelectedLocale.Identifier.Code == "es")
        {
            InsulationQuestionText.text = "¿Dónde está ubicado el defecto?";
        }
        else
        {
            InsulationQuestionText.text = "Where is the defect located?";
        }
    }
    public void PipeQuestionWrong()
    {
        if (LocalizationSettings.SelectedLocale.Identifier.Code == "es")
        {
            StartCoroutine(ChangeQuestionText2("Incorrecto. Inténtalo de nuevo."));
        }
        else
        {
            StartCoroutine(ChangeQuestionText2("Incorrect. Try again."));
        }
    }
    public IEnumerator ChangeQuestionText2(string newText)
    {        
        Debug.Log("ChangedText");
        PipeQuestionText.text = newText;
        yield return new WaitForSeconds(1.5f);
        if (LocalizationSettings.SelectedLocale.Identifier.Code == "es")
        {
            PipeQuestionText.text = "¿Dónde está ubicado el defecto?";
        }
        else
        {
            PipeQuestionText.text = "Where is the defect located?";
        }
    }
    public void QuestionWrong4()
    {
        if (LocalizationSettings.SelectedLocale.Identifier.Code == "es")
        {
            StartCoroutine(ChangeQuestionText3("Incorrecto. Inténtalo de nuevo."));
        }
        else
        {
            StartCoroutine(ChangeQuestionText3("Incorrect. Try again."));
        }
    }
    public IEnumerator ChangeQuestionText3(string newText)
    {
        Debug.Log("ChangedText");
        HVACQuestionText.text = newText;
        yield return new WaitForSeconds(1.5f);
        if (LocalizationSettings.SelectedLocale.Identifier.Code == "es")
        {
            HVACQuestionText.text = "¿Dónde está ubicado el defecto?";
        }
        else
        {
            HVACQuestionText.text = "Where is the defect located?";
        }
    }   
}
