using NUnit.Framework;
using UnityEngine;
using UnityEngine.EventSystems;
public class AnimationButton : MonoBehaviour , IPointerEnterHandler , IPointerExitHandler , IPointerDownHandler , IPointerUpHandler
{
    public float scaleFactor = 1.4f;
    public float pressScale = 0.9f;
    private Vector3 originalScale;
    bool isHovering ;
    
    public void Start()
    {
        originalScale = transform.localScale;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        isHovering = true;
        transform.localScale = originalScale * scaleFactor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isHovering = false;
        transform.localScale = originalScale;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        transform.localScale = originalScale * pressScale;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        transform.localScale = isHovering ? originalScale * scaleFactor : originalScale;
    }
}
