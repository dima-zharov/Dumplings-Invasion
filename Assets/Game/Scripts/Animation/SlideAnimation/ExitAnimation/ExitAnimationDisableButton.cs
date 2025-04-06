using DG.Tweening;
using UnityEngine;

public class ExitAnimationDisableButton : ExitAnimation
{
    [SerializeField] private ButtonIntaracteble _appearanceButtomHandler;

    protected override void MoveObject(Vector2 position)
    {
        _appearanceButtomHandler.DisableButton();
        StartExitAnimation(position).OnComplete(() =>
        {
            ResumePosition();
            _appearanceButtomHandler.EnableButton();
        });
    }
}
