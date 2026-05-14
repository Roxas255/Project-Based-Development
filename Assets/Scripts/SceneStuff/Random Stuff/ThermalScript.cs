using UnityEngine;

public class ThermalScript : MonoBehaviour
{
    public GameObject normal;
    public GameObject thermal;

    public bool check;
    public static ThermalScript instance;
    public AudioSource thermalAudio;
    void Start()
    {
        instance = this;
        check = false;
    }

    void Update()
    {
        if (check == false)
        {
            normal.SetActive(true);
            thermal.SetActive(false);
        }
        if (check == true)
        {
            normal.SetActive(false);
            thermal.SetActive(true);
        }
    }

    public void ButtonOnOff()
    {
        if (!check)
        {
            check = true;
        }
        else if (check)
        {
            check = false;
        }
    }

    public void PlayThermalSound()
    {
        thermalAudio.Play();
    }
}
