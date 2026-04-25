using TMPro;
using UnityEngine;

public class HVACminigame : MonoBehaviour
{
    [Header("UI")]
    
    public TMP_Text acButtonText;

    [Header("Objects")]
    public GameObject closedVent;
    public GameObject openVent;
    public GameObject dirtyFilter;
    public GameObject cleanFilter;

    private bool acOn = true;
    private bool ventOpen = false;
    private bool dirtyFilterRemoved = false;
    private bool cleanFilterInserted = false;

    void Start()
    {
        closedVent.SetActive(true);
        openVent.SetActive(false);
        dirtyFilter.SetActive(false);
        cleanFilter.SetActive(true);

        UpdateACText();
        
    }

    public void ToggleAC()
    {
        if (acOn)
        {
            acOn = false;
           
        }
        else
        {
            acOn = true;

            
                
        }

        UpdateACText();
    }

    public void OpenVent()
    {
        if (acOn)
        {
            
            return;
        }

        ventOpen = true;
        closedVent.SetActive(false);
        openVent.SetActive(true);
        dirtyFilter.SetActive(true);

        
    }

    public bool CanRemoveDirtyFilter()
    {
        return !acOn && ventOpen;
    }

    public void DirtyFilterDraggedOut()
    {
        dirtyFilterRemoved = true;
        dirtyFilter.SetActive(false);

        
    }

    public bool CanInsertCleanFilter()
    {
        return dirtyFilterRemoved;
    }

    public void CleanFilterInserted()
    {
        cleanFilterInserted = true;
       
    }

    public bool IsComplete()
    {
        return dirtyFilterRemoved && cleanFilterInserted && acOn;
    }

    void UpdateACText()
    {
        acButtonText.text = acOn ? "AC: ON" : "AC: OFF";
    }
}
