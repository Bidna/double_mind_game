using UnityEngine;

public class MultiworldObject : MonoBehaviour
{
    public GameObject normalWorldVersion;
    public GameObject paranormalWorldVersion;

    private void Awake()
    {
        GameManager.OnWorldChange += delegate(bool NormalWorld)
        {
            if (normalWorldVersion != null) normalWorldVersion.SetActive(NormalWorld);
            if (paranormalWorldVersion != null) paranormalWorldVersion.SetActive(!NormalWorld);
        };
    }
    private void OnEnable()
    {
        if (normalWorldVersion != null) normalWorldVersion.SetActive(FindObjectOfType<GameManager>().NormalWorld);
        if (paranormalWorldVersion != null) paranormalWorldVersion.SetActive(!FindObjectOfType<GameManager>().NormalWorld);
    }
}
