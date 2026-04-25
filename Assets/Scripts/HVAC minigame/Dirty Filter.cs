using UnityEngine;
using UnityEngine.EventSystems;

public class DirtyFilter : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public HVACminigame hvacMinigame;

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
        if (!hvacMinigame.CanRemoveDirtyFilter())
            return;

        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (!hvacMinigame.CanRemoveDirtyFilter())
        {
            rectTransform.anchoredPosition = startPosition;
            return;
        }

        hvacMinigame.DirtyFilterDraggedOut();
    }
}
