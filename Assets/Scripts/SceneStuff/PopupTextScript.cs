using System.Collections;
using TMPro;
using UnityEngine;

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
    void Start()
    {
        if (GameManager.instance.WindowMinigameComplete == false)
        {
            tutorialText.SetActive(true);
        }
    }
    void Update()
    {
        
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
        WindowInfoPanel.SetActive(true);
        WindowQuestionText.text = newText;
        yield return new WaitForSeconds(2f);
        WindowQuestionText.text = ("Where is the defect located?");
    }   
}
