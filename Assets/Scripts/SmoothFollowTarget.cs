using UnityEngine;

public class SmoothFollowTarget : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private Vector3 offset;
    [SerializeField]
    private Transform target;

    private void Update()
    {
        if (target == null)
        {
            target = FindObjectOfType<Player>()?.transform;
        }
        if (target == null) return;
        var position = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, position, speed * Time.deltaTime);
    }
}
