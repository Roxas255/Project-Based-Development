using UnityEngine;

public class ThermalScript2 : MonoBehaviour
{
    public GameObject normal;
    public GameObject thermal;

    public GameObject WindowButton;
    public GameObject InsulationButton;
    public Animator WindowButtonAnimator;
    public Animator InsulationButtonAnimator;
    public bool check;
    public static ThermalScript2 instance;
    void Start()
    {
        instance = this;
        check = false;
    }

    void Update()
    {
        if (check == false)
        {
            normal.SetActive(true);
            thermal.SetActive(false);
        }
        if (check == true)
        {
            normal.SetActive(false);
            thermal.SetActive(true);
        }
    }

    public void ButtonOnOff()
    {
        if (!check)
        {
            check = true;
            TurnOnMinigameButtons();
        }
        else if (check)
        {
            check = false;
            TurnOffMinigameButtons();
        }
    }
    
    public void TurnOnMinigameButtons()
    {
        if (!GameManager.instance.WindowMinigameComplete)
            WindowButton.SetActive(true);
            WindowButtonAnimator.SetTrigger("Highlight2");
        
        if (!GameManager.instance.InsulationMinigameComplete)
            InsulationButton.SetActive(true);
            InsulationButtonAnimator.SetTrigger("Highlight3");
    }
    public void TurnOffMinigameButtons()
    {
        WindowButton.SetActive(false);
        InsulationButton.SetActive(false);
    }
}
