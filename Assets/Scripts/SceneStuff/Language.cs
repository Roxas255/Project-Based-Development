using TMPro;
using UnityEngine;
using UnityEngine.Localization.Settings;

public class Language : MonoBehaviour
{
    [SerializeField] TMP_Dropdown dropdown; // UI dropdown player uses to change language

    private async void Start()
    {   // Waits for localization to initialize
        await LocalizationSettings.InitializationOperation.Task;
        dropdown.onValueChanged.AddListener(ChangeLanguage);
    }
    //When player to decides to change the language 
    public void ChangeLanguage(int index)
    {
        LocalizationSettings.SelectedLocale =
            LocalizationSettings.AvailableLocales.Locales[index];
    }
}
