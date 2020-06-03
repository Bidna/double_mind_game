using UnityEngine;
using UnityEngine.EventSystems;

class MovePlayerButton  : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public float runDirection;
    
    void Update()
    {
        if (!isPressed)
            return;
        
        FindObjectOfType<Player>()?.SetRunDirection(runDirection);;
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