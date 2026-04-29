using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.Localization.Settings; 

public class Dialouge : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;

    [Header("Spanish Lines")] 
    public string[] spanishLines;

    public float textSpeed;
    public GameObject Panel;
    public GameObject button;
    private int index;

    private string[] currentLines; 

    private void Start()
    {
        textComponent.text = string.Empty;

        //decides which language is being used 
        string languageCode = LocalizationSettings.SelectedLocale.Identifier.Code;

        if (languageCode == "es")
        {
            currentLines = spanishLines;
        }
        else
        {
            currentLines = lines;
        }

        StartDialogue();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (textComponent.text == currentLines[index]) 
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = currentLines[index]; 
            }
        }
    }

    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in currentLines[index].ToCharArray()) 
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if (index < currentLines.Length - 1) 
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            
            if (button != null)
            {
                button.SetActive(true);
            }
            if (button == null)
            {
                gameObject.SetActive(false);
            }
        }
    }
}