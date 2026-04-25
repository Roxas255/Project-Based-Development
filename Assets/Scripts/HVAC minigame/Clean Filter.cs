using UnityEngine;
using UnityEngine.EventSystems;

public class CleanFilter : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public HVACminigame hvacMinigame;
    public RectTransform ventTarget;

    public float snapDistance = 80f;

    private RectTransform rectTransform;
    private Canvas canvas;
    private Vector2 startPosition;

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        startPosition = rectTransform.anchoredPosition;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!hvacMinigame.CanInsertCleanFilter())
            return;

        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (!hvacMinigame.CanInsertCleanFilter())
        {
            rectTransform.anchoredPosition = startPosition;
            return;
        }

        float distance = Vector2.Distance(rectTransform.anchoredPosition, ventTarget.anchoredPosition);

        if (distance <= snapDistance)
        {
            rectTransform.anchoredPosition = ventTarget.anchoredPosition;
            hvacMinigame.CleanFilterInserted();
        }
        else
        {
            rectTransform.anchoredPosition = startPosition;
        }
    }
}
