using UnityEngine;

public class Musicbutton : MonoBehaviour
{
   
    public AudioSource audioSource;

    public void PlayButtonSound()
    {
        audioSource.Play();
    }
}

