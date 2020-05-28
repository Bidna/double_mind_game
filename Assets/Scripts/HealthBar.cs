using UnityEngine;

public class HealthBar : MonoBehaviour
{
    private readonly Transform[] hearts = new Transform[3];

    private void Awake()
    {
        for (var i = 0; i < hearts.Length; i++) 
            hearts[i] = transform.GetChild(i);
    }

    public void SetHp(int value)
    {
        for (var i = 0; i < hearts.Length; i++) 
            hearts[i].gameObject.SetActive(i < value);
    }
}
