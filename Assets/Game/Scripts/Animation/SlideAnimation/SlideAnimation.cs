using System;
using UnityEngine;

public abstract class SlideAnimation : MonoBehaviour, IAnimation
{
    [field: SerializeField] public float DurationAnimation { get; protected set; }
    [SerializeField] protected AnimationDirection _animationDirection;
    [SerializeField] protected float _offscreenMarginPixels = 10f;

    protected event Action<int, int> OnResolutionChanged;

    protected float _widthUI;
    protected float _heightUI;
    private int _lastWidth;
    protected int _lastHeight;

    protected Vector2 _targetAnchoredPosition;

    protected RectTransform _rectTransform;
    protected Canvas _canvas;
    protected Camera _canvasCamera;
    protected RectTransform _canvasRect;

    private Vector2 _elementScreenSize;
    private Vector2 _normalizedScreenPos;

    protected enum AnimationDirection
    {
        Top,
        Down,
        Left,
        Right
    };

    private void OnEnable()
    {
        OnResolutionChanged += HandleResolutionChanged;
    }
    private void OnDisable()
    {
        OnResolutionChanged -= HandleResolutionChanged;
    }

    protected void Awake()
    {
        _rectTransform = transform as RectTransform;
        _targetAnchoredPosition = _rectTransform.anchoredPosition;

        _canvas = _rectTransform.GetComponentInParent<Canvas>();
        _canvasCamera = _canvas.GetComponent<Camera>();
        _canvasRect = _canvas.GetComponent<RectTransform>();

        _widthUI = _rectTransform.rect.width;
        _heightUI = _rectTransform.rect.height;

        Vector2 screenPoint = RectTransformUtility.WorldToScreenPoint(_canvasCamera, _rectTransform.position);
        _normalizedScreenPos = new Vector2(screenPoint.x / Screen.width, screenPoint.y / Screen.height);

        RectTransformUtility.ScreenPointToLocalPointInRectangle(_canvasRect, screenPoint, _canvasCamera, out Vector2 localPoint);
        _targetAnchoredPosition = localPoint;


        _elementScreenSize = GetScreenSizeInPixels(_rectTransform);

        _lastWidth = Screen.width;
        _lastHeight = Screen.height;
    }
    protected void Update()
    {
        if (Screen.width != _lastWidth || Screen.height != _lastHeight)
        {
            _lastWidth = Screen.width;
            _lastHeight = Screen.height;
            OnResolutionChanged?.Invoke(Screen.width, Screen.height);
        }
    }

    private void HandleResolutionChanged(int width, int height)
    {

        Vector2 newScreenPoint = new Vector2(_normalizedScreenPos.x * width, _normalizedScreenPos.y * height);


        RectTransformUtility.ScreenPointToLocalPointInRectangle(_canvasRect, newScreenPoint, _canvasCamera, out Vector2 newLocal);
        _targetAnchoredPosition = newLocal;

  
        _elementScreenSize = GetScreenSizeInPixels(_rectTransform);
    }
    private Vector2 GetScreenSizeInPixels(RectTransform rt)
    {
        Vector3[] worldCorners = new Vector3[4];
        rt.GetWorldCorners(worldCorners);
        Vector2 sp0 = RectTransformUtility.WorldToScreenPoint(_canvasCamera, worldCorners[0]);
        Vector2 sp2 = RectTransformUtility.WorldToScreenPoint(_canvasCamera, worldCorners[2]);
        return new Vector2(Mathf.Abs(sp2.x - sp0.x), Mathf.Abs(sp2.y - sp0.y));
    }
    protected Vector2 CalculateOffscreenAnchored(AnimationDirection dir)
    {

        Vector2 targetScreenPoint = new Vector2(_normalizedScreenPos.x * Screen.width, _normalizedScreenPos.y * Screen.height);

        Vector2 offscreenScreenPoint = targetScreenPoint;

        float halfW = _elementScreenSize.x * 0.5f;
        float halfH = _elementScreenSize.y * 0.5f;

        switch (dir)
        {
            case AnimationDirection.Top:
                offscreenScreenPoint.y = Screen.height + halfH + _offscreenMarginPixels;
                break;
            case AnimationDirection.Down:
                offscreenScreenPoint.y = -(halfH + _offscreenMarginPixels);
                break;
            case AnimationDirection.Right:
                offscreenScreenPoint.x = Screen.width + halfW + _offscreenMarginPixels;
                break;
            case AnimationDirection.Left:
                offscreenScreenPoint.x = -(halfW + _offscreenMarginPixels);
                break;
        }


        RectTransformUtility.ScreenPointToLocalPointInRectangle(_canvasRect, offscreenScreenPoint, _canvasCamera, out Vector2 offLocal);
        return offLocal;
    }

    public virtual void StartAnimation()
    {
        Vector2 off = CalculateOffscreenAnchored(_animationDirection);
        MoveObject(off);
    }


    protected abstract void MoveObject(Vector2 position);

}
