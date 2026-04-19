using UnityEngine;

public class Popups2 : MonoBehaviour
{
    public Animator InsulationButtonAnimator;
    public GameObject InsulationButton;
    public GameObject PipeButton;
    
    void Update()
    {
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
            if (GameManager.instance.WindowMinigameComplete && ThermalScript.instance.check == true)
            {
                InsulationButtonAnimator.SetTrigger("Highlight3");
            }
            else if (GameManager.instance.WindowMinigameComplete && !ThermalScript.instance.check)
            {
                InsulationButtonAnimator.ResetTrigger("Highlight3");
            }
        }
        else if (GameManager.instance.InsulationMinigameComplete)
        {
            return;
        }
    }
}
