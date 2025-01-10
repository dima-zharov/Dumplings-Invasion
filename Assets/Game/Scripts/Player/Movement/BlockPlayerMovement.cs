using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class BlockPlayerMovement : MonoBehaviour
{
    public void BlockMovement() => GetComponent<PlayerMovement>().enabled = false;
    public void EnableMovement() => GetComponent<PlayerMovement>().enabled = true;
}
