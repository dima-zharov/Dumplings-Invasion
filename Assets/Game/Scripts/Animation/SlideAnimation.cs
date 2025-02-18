using DG.Tweening;
using UnityEngine;

public class SlideAnimation : MonoBehaviour
{
    [SerializeField] private float _durationAnimation;
    [SerializeField] private AnimationDirection _animationDirection;

    private Vector2 _targetPosition;

    private float _rightEdge = Screen.width / 2;
    private float _leftEdge = -Screen.width / 2;
    private float _topEdge = Screen.height / 2;
    private float _downEdge = -Screen.height / 2;
    private float _widthUI;
    private float _heightUI;

    private RectTransform _rectTransform;

    private enum AnimationDirection
    {
        Top,
        Down,
        Left,
        Right
    };

    private void Start()
    {
        _targetPosition = transform.position;
        _rectTransform = transform as RectTransform;

        _widthUI = _rectTransform.rect.width / 2;
        _heightUI = _rectTransform.rect.height / 2;
    }

    public void StartAnimation()
    {
        switch (_animationDirection)
        {
            case (AnimationDirection.Top):
                MoveObject(new Vector2(0, _topEdge + _heightUI));
                break;
            case (AnimationDirection.Down):
                MoveObject(new Vector2(0, _downEdge - _heightUI));
                break;
            case (AnimationDirection.Right):
                MoveObject(new Vector2(_rightEdge + _widthUI, 0));
                break;
            case (AnimationDirection.Left):
                MoveObject(new Vector2(_leftEdge - _widthUI, 0));
                break;
        }
    }


    private void MoveObject(Vector2 position)
    {
        _rectTransform.DOAnchorPos(position, _durationAnimation).SetEase(Ease.InOutSine).OnComplete(ResumePosition);
    }

    private void ResumePosition()
    {
        gameObject.SetActive(false);
        transform.position = _targetPosition;
    }
}
