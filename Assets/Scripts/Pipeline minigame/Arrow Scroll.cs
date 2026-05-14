using UnityEngine;
using UnityEngine.UI;

public class ArrowScroll : MonoBehaviour
{
    public Image tileTop;
    public Image tileUpperMid;
    public Image tileLowerMid;
    public Image tileBottom;

    public AudioSource pipeAudio;

    public void ScrollUp()
    {
        pipeAudio.Play();

        Sprite temp = tileTop.sprite;

        tileTop.sprite = tileUpperMid.sprite;
        tileUpperMid.sprite = tileLowerMid.sprite;
        tileLowerMid.sprite = tileBottom.sprite;
        tileBottom.sprite = temp;
    }

    public void ScrollDown()
    {
        pipeAudio.Play();

        Sprite temp = tileBottom.sprite;

        tileBottom.sprite = tileLowerMid.sprite;
        tileLowerMid.sprite = tileUpperMid.sprite;
        tileUpperMid.sprite = tileTop.sprite;
        tileTop.sprite = temp;
    }
}