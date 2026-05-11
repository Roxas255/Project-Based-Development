using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Level2Popups : MonoBehaviour
{
    public GameObject InitialText;
    public GameObject BTUIntro;
    public GameObject BTUPanel;
    public GameObject BTUInfoPanel;
    public GameObject Text2;


    public GameObject HVACbutton;
    public GameObject PipeButton;

    public static Level2Popups instance;
    void Start()
    {

        instance = this;

        InitialText.SetActive(true);
        if (GameManager.instance.checked4 == true && GameManager.instance.HVACWrong == true)
        {
            StartCoroutine(GameManager.instance.HvacWrongCheckOnOff());
        }
        if (GameManager.instance.checked3 == true && GameManager.instance == true)
        {
            StartCoroutine(GameManager.instance.PipeWrongCheckOnOff());
            Debug.Log("PipeBUtton");
            PipeButton.SetActive(true);
        }
    }

    void Update()
    {
        if (!InitialText.activeSelf && !GameManager.instance.playedThermalIntro)
        {
            ShowBTUPanel();
            GameManager.instance.playedThermalIntro = true;
        }
    }

    public void ShowBTUPanel()
    {
        BTUInfoPanel.SetActive(true);
        GameManager.instance.playedIntro = true;
        Text2.SetActive(true);
    }

    public void ToggleBTUPanel()
    {
        BTUInfoPanel.SetActive(!BTUInfoPanel.activeSelf);
    }
}
