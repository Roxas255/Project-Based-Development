using UnityEngine;

public class Level2Popups : MonoBehaviour
{
    public GameObject InitialText;
    public GameObject BTUIntro;
    public GameObject BTUPanel;
    public GameObject BTUInfoPanel;
  //  public GameObject 
    void Start()
    {
        InitialText.SetActive(true);
        GameManager.instance.playedIntro = true;
    }

    void Update()
    {
        if (InitialText.activeSelf == false)
        {
            BTUIntro.SetActive(true);
            BTUPanel.SetActive(true);
            GameManager.instance.playedThermalIntro = true; //ignorre the bool name. It is the 2nd popup.
            BTUInfoPanel.SetActive(true); 
        }
    }

    public void BTUPanelOnOff()
    {
        BTUInfoPanel.SetActive(!BTUInfoPanel.activeSelf);
    }
}
