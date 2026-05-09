using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Localization.Settings;

public class Popups2 : MonoBehaviour
{
    public Animator InsulationButtonAnimator;
    public GameObject InsulationButton;
    public GameObject PipeButton;
    public GameObject HVACButton;
    public TextMeshProUGUI BTUText;
    
    void Update()
    {

        Scene currentScene = SceneManager.GetActiveScene();

        if (currentScene.name == "Level 2")
        {
            Debug.Log("UpdatedBTUText");
            if (LocalizationSettings.SelectedLocale.Identifier.Code == "es")
            {
                BTUText.text = "BTU actual: " + GameManager.instance.CurrentBTU.ToString();
            }
            else
            {
                BTUText.text = "Current BTU: " + GameManager.instance.CurrentBTU.ToString();
            }
        }






        if (GameManager.instance.InsulationMinigameComplete)
        {
            InsulationButton.SetActive(false);
        }
        if (GameManager.instance.PipeMinigameComplete)
        {
            PipeButton.SetActive(false);
        }
        if (!GameManager.instance.InsulationMinigameComplete)
        {
            if (currentScene.name == ("Level2"))
            {
                    
                if (GameManager.instance.WindowMinigameComplete && ThermalScript.instance.check == true)
                {
                    InsulationButtonAnimator.SetTrigger("Highlight3");
                }
                else if (GameManager.instance.WindowMinigameComplete && !ThermalScript.instance.check)
                {
                    InsulationButtonAnimator.ResetTrigger("Highlight3");
                }
                if (GameManager.instance.WindowMinigameComplete && ThermalScript.instance.check == true)
                {
                    InsulationButtonAnimator.SetTrigger("Highlight3");
                }
                else if (GameManager.instance.WindowMinigameComplete && !ThermalScript.instance.check)
                {
                    InsulationButtonAnimator.ResetTrigger("Highlight3");
                }
            }
    
        }
        else if (GameManager.instance.InsulationMinigameComplete)
        {
            return;
        }

        if (GameManager.instance.HvacMinigameComplete)
        {
            HVACButton.SetActive(false);
        }
    }
}
