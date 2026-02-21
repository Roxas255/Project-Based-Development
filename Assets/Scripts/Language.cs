using TMPro;
using UnityEngine;
using UnityEngine.Localization.Settings;

public class Language : MonoBehaviour
{
    [SerializeField] TMP_Dropdown dropdown;

    private async void Start()
    {
        await LocalizationSettings.InitializationOperation.Task;
        dropdown.onValueChanged.AddListener(ChangeLanguage);
    }

    public void ChangeLanguage(int index)
    {
        LocalizationSettings.SelectedLocale =
            LocalizationSettings.AvailableLocales.Locales[index];
    }
}
