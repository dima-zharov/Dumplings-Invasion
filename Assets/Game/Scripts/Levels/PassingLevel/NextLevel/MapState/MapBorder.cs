using UnityEngine;

public class MapBorder : MonoBehaviour
{
    public GameObject FirstPlatform { get; private set; }
    private void OnTriggerEnter(Collider collision)
    {
        if(FirstPlatform == null)
            FirstPlatform = collision.gameObject.GetComponent<PlatformData>().gameObject;
    }

    private void OnTriggerExit(Collider other)
    {
        FirstPlatform = null;
    }


}
