using UnityEngine;
using UnityEngine.EventSystems;

class JumpPlayerButton  : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    void Update()
    {
        if (!isPressed)
            return;
        
        FindObjectOfType<Player>()?.SetJump();;
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