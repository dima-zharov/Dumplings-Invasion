using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeBuyAnimation : MonoBehaviour
{
    [SerializeField] private Color _startImageColor;
    [SerializeField] private Color _sucessfulUpgradeColor;
    [SerializeField] private Color _errorUpgradeColor;
    [SerializeField] private float _duration;

    public void ChooseUpgradeAnimation(bool isBuySuccessful, Image image)
    {
        if (isBuySuccessful)
            EnableAnimation(image, _sucessfulUpgradeColor);
        else
            EnableAnimation(image, _errorUpgradeColor);
    }

    private void EnableAnimation(Image image, Color color)
    {
        image.DOColor(color, _duration).OnComplete(() => image.DOColor(_startImageColor, _duration));
        
    }

    public void EnableUpgradeAnimtion(Image image) => EnableAnimation(image, _sucessfulUpgradeColor);
    public void DisableUpgradeAnimtion(Image image) => EnableAnimation(image, _errorUpgradeColor);
}
