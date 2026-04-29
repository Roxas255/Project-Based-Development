using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HVACminigame : MonoBehaviour
{
    [Header("UI")]


    [Header("Filter Objects")]
    public GameObject dirtyFilter;
    public GameObject cleanFilter;

    [Header("HVAC State Sprites")]
    public Image hvacImage;

    public Sprite f1_ACOnClosed;
    public Sprite f2_ACOffClosed;
    public Sprite f3_VentOpening;
    public Sprite f4_VentOpenDirty;
    public Sprite f5_VentOpenEmpty;
    public Sprite f6_VentOpenClean;

    private bool acOn = true;
    private bool ventOpen = false;
    private bool dirtyFilterRemoved = false;
    private bool cleanFilterInserted = false;

    void Start()
    {
        // Start state: AC is ON and vent is closed
        acOn = true;
        ventOpen = false;
        dirtyFilterRemoved = false;
        cleanFilterInserted = false;

        hvacImage.sprite = f1_ACOnClosed;

        // Dirty filter should not be dragged until the vent is open
        dirtyFilter.SetActive(false);

        // Clean filter starts available in its slot/tray
        cleanFilter.SetActive(true);

        
    }

    public void ToggleAC()
    {
        // Player should not turn AC on/off while vent is open
        if (ventOpen)
            return;

        acOn = !acOn;

        if (acOn)
        {
            hvacImage.sprite = f1_ACOnClosed;
        }
        else
        {
            hvacImage.sprite = f2_ACOffClosed;
        }

        
    }

    public void OpenVent()
    {
        if (acOn)
            return;

        if (!ventOpen)
        {
            ventOpen = true;

            if (cleanFilterInserted)
            {
                // If clean filter is already installed, show clean filter when opened
                hvacImage.sprite = f6_VentOpenClean;
            }
            else if (dirtyFilterRemoved)
            {
                // If dirty filter was removed but clean is not in yet
                hvacImage.sprite = f5_VentOpenEmpty;
            }
            else
            {
                // First time opening, dirty filter is still there
                hvacImage.sprite = f4_VentOpenDirty;
                dirtyFilter.SetActive(true);
            }
        }
        else
        {
            CloseVent();
        }
    }

    private void CloseVent()
    {
        // Player can only close the vent after clean filter is inserted
        if (!cleanFilterInserted)
            return;

        ventOpen = false;

        // After closing vent, AC is still OFF, so show F2
        hvacImage.sprite = f2_ACOffClosed;
    }

    public bool CanRemoveDirtyFilter()
    {
        return !acOn && ventOpen && !dirtyFilterRemoved;
    }

    public void DirtyFilterDraggedOut()
    {
        dirtyFilterRemoved = true;

        // Change background immediately to empty vent
        hvacImage.sprite = f5_VentOpenEmpty;
    }

    public void HideDirtyFilter()
    {
        dirtyFilter.SetActive(false);
    }

    public bool CanInsertCleanFilter()
    {
        return !acOn && ventOpen && dirtyFilterRemoved && !cleanFilterInserted;
    }

    public void CleanFilterInserted()
    {
        cleanFilterInserted = true;

        // Hide the draggable clean filter object
        cleanFilter.SetActive(false);

        // Show the background image with the clean filter installed
        hvacImage.sprite = f6_VentOpenClean;
    }

    public bool IsComplete()
    {
        // Complete only if dirty removed, clean inserted, vent closed, and AC back ON
        return dirtyFilterRemoved && cleanFilterInserted && !ventOpen && acOn;
    }

}