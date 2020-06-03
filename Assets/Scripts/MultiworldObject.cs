using UnityEngine;

public class MultiworldObject : MonoBehaviour
{
    public GameObject normalWorldVersion;
    public GameObject paranormalWorldVersion;

    private void Awake()
    {
        GameManager.OnWorldChange += delegate(bool x)
        {
            if (normalWorldVersion != null) normalWorldVersion.SetActive(x);
            if (paranormalWorldVersion != null) paranormalWorldVersion.SetActive(!x);
        };
    }
}
