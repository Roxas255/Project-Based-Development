using UnityEngine;

public class ThermalScript : MonoBehaviour
{
    public GameObject normal;
    public GameObject thermal;

    public bool check;
    void Start()
    {
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
}
