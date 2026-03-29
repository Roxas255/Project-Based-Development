using UnityEngine;
using UnityEngine.UI;
public class ArrowScroll : MonoBehaviour
{
    public Image tileTop;
    public Image tileUpperMid;
    public Image tileLowerMid;
    public Image tileBottom;

    public void ScrollUp()
    {
        Sprite temp = tileTop.sprite;

        tileTop.sprite = tileUpperMid.sprite;
        tileUpperMid.sprite = tileLowerMid.sprite;
        tileLowerMid.sprite = tileBottom.sprite;
        tileBottom.sprite = temp;
    }

    public void ScrollDown()
    {
        Sprite temp = tileBottom.sprite;

        tileBottom.sprite = tileLowerMid.sprite;
        tileLowerMid.sprite = tileUpperMid.sprite;
        tileUpperMid.sprite = tileTop.sprite;
        tileTop.sprite = temp;
    }
}
