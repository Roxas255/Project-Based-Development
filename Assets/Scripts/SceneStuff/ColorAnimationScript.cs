using UnityEngine;

public class ColorAnimationScript : MonoBehaviour
{
    public Animator anim;

    void OnEnable()
    {
        anim.ResetTrigger("StopHighlight");
        anim.SetTrigger("Highlight");
    }
    void OnDisable()
    {
        anim.ResetTrigger("Highlight");
        anim.SetTrigger("StopHighlight");
    }
}
