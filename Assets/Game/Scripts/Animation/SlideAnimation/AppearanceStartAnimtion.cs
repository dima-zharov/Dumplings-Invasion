using DG.Tweening;
using UnityEngine;
public class AppearanceStartAnimtion : SlideAnimation
{
    [SerializeField] private Vector2 _positionToMove;

    protected override void MoveObject(Vector2 position)
    {
        _rectTransform.DOAnchorPos(position, DurationAnimation)
           .SetEase(Ease.InOutSine)
           .OnUpdate(() =>
           {
               if (Vector2.Distance(_rectTransform.anchoredPosition, position) < 0.1f)
               {
                   _rectTransform.DOKill(); 
                   _rectTransform.anchoredPosition = position; 
               }
           });
    }

    public override void StartAnimation()
    {
        MoveObject(_positionToMove);
    }
}
