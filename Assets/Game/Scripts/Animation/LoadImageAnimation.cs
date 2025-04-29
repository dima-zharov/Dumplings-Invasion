using DG.Tweening;
using UnityEngine;

public class LoadImageAnimation : MonoBehaviour
{
    [SerializeField] private GameBeginning _gameBeggining;
    [SerializeField] private float _animationSpeed;
    [SerializeField] private RestartLevel _restartLevel;
    [SerializeField] private ButtonIntaracteble _buttonState;

    private RectTransform _imageTransform;
    private float _imagePosition;
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

        _imagePosition = _imageTransform.offsetMin.x;
    }

    public void PlayAnimation()
    {
        _buttonState.DisableButton();
        _imageTransform.DOMoveX(_imagePosition - _imagePosition / 2, _animationSpeed).SetLoops(2, LoopType.Yoyo).OnComplete(_buttonState.EnableButton);
    }

}
