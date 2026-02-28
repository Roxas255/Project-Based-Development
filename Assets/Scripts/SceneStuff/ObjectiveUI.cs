using TMPro;
using UnityEngine;

public class ObjectiveUI : MonoBehaviour
{
    [SerializeField] private GameObject objectivePopup;
    [SerializeField] private TMP_Text objectiveText;

    [TextArea]
    [SerializeField]
    private string levelObjective =
        "Fix the Lights.";

    void Start()
    {
        objectivePopup.SetActive(false);
        objectiveText.text = levelObjective;
    }

    public void ToggleObjective()
    {
        objectivePopup.SetActive(!objectivePopup.activeSelf);
    }
}
