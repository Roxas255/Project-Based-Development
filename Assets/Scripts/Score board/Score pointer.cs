using System.Collections;
using UnityEngine;

public class Scorepointer : MonoBehaviour
{
    [SerializeField] private RectTransform pointer;

    [Header("Bar Points")]
    [SerializeField] private RectTransform redStart;
    [SerializeField] private RectTransform orangeStart;
    [SerializeField] private RectTransform yellowStart;
    [SerializeField] private RectTransform greenStart;
    [SerializeField] private RectTransform greenEnd;

    [Header("Animation")]
    [SerializeField] private float moveDuration = 1.5f;

    public void MovePointer(float score)
    {
        score = Mathf.Clamp(score, 0f, 45f);

        Vector2 targetPos = GetTargetPosition(score);

        StopAllCoroutines();
        StartCoroutine(MoveRoutine(targetPos));
    }

    private Vector2 GetTargetPosition(float score)
    {
        float targetX;

        if (score <= 11.25f)
        {
            float t = score / 11.25f;
            targetX = Mathf.Lerp(redStart.anchoredPosition.x, orangeStart.anchoredPosition.x, t);
        }
        else if (score <= 22.5f)
        {
            float t = (score - 11.25f) / 11.25f;
            targetX = Mathf.Lerp(orangeStart.anchoredPosition.x, yellowStart.anchoredPosition.x, t);
        }
        else if (score <= 33.75f)
        {
            float t = (score - 22.5f) / 11.25f;
            targetX = Mathf.Lerp(yellowStart.anchoredPosition.x, greenStart.anchoredPosition.x, t);
        }
        else
        {
            float t = (score - 33.75f) / 11.25f;
            targetX = Mathf.Lerp(greenStart.anchoredPosition.x, greenEnd.anchoredPosition.x, t);
        }

        return new Vector2(targetX, pointer.anchoredPosition.y);
    }

    private IEnumerator MoveRoutine(Vector2 target)
    {
        Vector2 start = pointer.anchoredPosition;
        float time = 0f;

        while (time < moveDuration)
        {
            time += Time.deltaTime;
            float t = time / moveDuration;
            t = Mathf.SmoothStep(0f, 1f, t);

            pointer.anchoredPosition = Vector2.Lerp(start, target, t);
            yield return null;
        }

        pointer.anchoredPosition = target;
    }
}
