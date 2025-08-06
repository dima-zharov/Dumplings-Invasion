using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource _availableSound;
    [SerializeField] private AudioSource _notEnoughtMoneySound;

    public void PlayPurchaseSound() => _availableSound.Play();
    public void PlayNotEnoughtMoneySound() => _notEnoughtMoneySound.Play();
}
