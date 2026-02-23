using UnityEngine;

public class SettingsScript : MonoBehaviour
{
    public GameObject settingsPanel;
    public void ToggleButton()
    {
        settingsPanel.SetActive(!settingsPanel.activeSelf);
    }
}
