using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class LongPressButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public UnityEvent onPress;
    void Update()
    {
        if (!isPressed)
            return;
        
        onPress?.Invoke();
    }

    private bool isPressed;
    public void OnPointerDown(PointerEventData eventData)
    {
        isPressed = true;
    }
 
    public void OnPointerUp(PointerEventData eventData)
    {
        isPressed = false;
    }
}
