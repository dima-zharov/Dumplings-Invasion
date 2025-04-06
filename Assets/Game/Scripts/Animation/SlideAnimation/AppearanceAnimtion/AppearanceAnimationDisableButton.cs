using DG.Tweening;
using UnityEngine;

public class AppearanceAnimationDisableButton : AppearanceStartAnimtion
{
    [SerializeField] private ButtonIntaracteble _appearanceButtomHandler;

    public override void StartAnimation()
    {
        _appearanceButtomHandler.DisableButton();
        StartAppearaneAnimation(_positionToMove).OnComplete(() => _appearanceButtomHandler.EnableButton());
    }
}
