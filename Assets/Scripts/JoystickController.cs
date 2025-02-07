using UnityEngine;
using UnityEngine.EventSystems;

public class JoystickController : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    private Vector2 inputVector;
    public RectTransform joystickBackground;
    private RectTransform joystickKnob;

    private void Start()
    {
        joystickKnob = GetComponent<RectTransform>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 dragPosition = eventData.position - (Vector2)joystickBackground.position;
        inputVector = Vector2.ClampMagnitude(dragPosition / (joystickBackground.sizeDelta / 2), 1f);
        joystickKnob.anchoredPosition = inputVector * (joystickBackground.sizeDelta / 2);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        inputVector = Vector2.zero;
        joystickKnob.anchoredPosition = Vector2.zero;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public float Horizontal() { return inputVector.x; }
    public float Vertical() { return inputVector.y; }
}
