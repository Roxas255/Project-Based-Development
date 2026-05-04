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
  //  public GameObject 
    void Start()
    {
        InitialText.SetActive(true);
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
