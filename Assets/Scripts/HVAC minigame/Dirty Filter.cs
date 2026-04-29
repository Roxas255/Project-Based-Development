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

        if (hvacMinigame.CanRemoveDirtyFilter())
        {
            hvacMinigame.DirtyFilterDraggedOut();
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (hvacMinigame != null)
        {
            hvacMinigame.HideDirtyFilter();
        }
    }
}
