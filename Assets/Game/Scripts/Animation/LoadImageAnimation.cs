using DG.Tweening;
using UnityEngine;

public class LoadImageAnimation : MonoBehaviour
{
    [SerializeField] private GameBeginning _gameBeggining;
    [SerializeField] private float _animationSpeed;
    [SerializeField] private RestartLevel _restartLevel;
    [SerializeField] private ButtonIntaracteble _buttonState;

    private RectTransform _imageTransform;
    private Vector2 _startOffsetMin;
    private Vector2 _startOffsetMax;
    private float _startImagePosition;
    private bool _isAnimating;

    private void OnEnable()
    {
        _restartLevel.OnRestartedLevel += PlayAnimation;
        _gameBeggining.OnGameFirstOpen += PlayAnimation;
    }
    private void OnDisable()
    {
        _restartLevel.OnRestartedLevel -= PlayAnimation;
        _gameBeggining.OnGameFirstOpen -= PlayAnimation;
    }


    private void Start()
    {
        _imageTransform = GetComponent<RectTransform>();
        _startImagePosition = _imageTransform.anchoredPosition.x + Screen.width / 2;
        _imageTransform.anchoredPosition = new Vector2(_startImagePosition, _imageTransform.anchoredPosition.y);
        _startOffsetMin = _imageTransform.offsetMin;
        _startOffsetMax = _imageTransform.offsetMax;
    }

    public void PlayAnimation()
    {
        _buttonState.DisableButton();

        DOTween.To(() => _imageTransform.offsetMin, x => _imageTransform.offsetMin = x,
            new Vector2(0, _startOffsetMin.y), _animationSpeed).SetEase(Ease.InOutQuad);

        DOTween.To(() => _imageTransform.offsetMax, x => _imageTransform.offsetMax = x,
            new Vector2(0, _startOffsetMax.y), _animationSpeed).SetEase(Ease.InOutQuad)
            .OnComplete(() =>
            {
                DOTween.To(() => _imageTransform.offsetMin, x => _imageTransform.offsetMin = x,
                    _startOffsetMin, _animationSpeed).SetEase(Ease.InOutQuad);

                DOTween.To(() => _imageTransform.offsetMax, x => _imageTransform.offsetMax = x,
                    _startOffsetMax, _animationSpeed).SetEase(Ease.InOutQuad)
                    .OnComplete(_buttonState.EnableButton);
            });
    }

}
