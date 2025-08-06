using UnityEngine;

public abstract class SlideAnimation : MonoBehaviour, IAnimation
{
    [field: SerializeField] public float DurationAnimation { get; protected set; }
    [SerializeField] protected AnimationDirection _animationDirection;
    

    protected Vector2 _targetPosition;

    protected float _rightEdge = Screen.width / 2;
    protected float _leftEdge = -Screen.width / 2;
    protected float _topEdge = Screen.height / 2;
    protected float _downEdge = -Screen.height / 2;
    protected float _widthUI;
    protected float _heightUI;

    protected RectTransform _rectTransform;

    protected enum AnimationDirection
    {
        Top,
        Down,
        Left,
        Right
    };

    protected void Awake()
    {
        _targetPosition = transform.position;
        _rectTransform = transform as RectTransform;

        _widthUI = _rectTransform.rect.width;
        _heightUI = _rectTransform.rect.height;
    }

    public virtual void StartAnimation()
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


    protected abstract void MoveObject(Vector2 position);

}
