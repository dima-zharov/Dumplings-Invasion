using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FrameByFrameAnimation : MonoBehaviour
{
    [SerializeField] private List<Sprite> _frames;
    [SerializeField] private float _frameDuration = 0.1f;
    [SerializeField] private bool _loop = true;
    [SerializeField] private bool _destroyAfterPlaying;

    private Image _currentImage;
    private Sequence _animationSequence;

    private void Start()
    {
        _currentImage = GetComponent<Image>();
        PlayAnimation();
        
    }

    public void PlayAnimation()
    {

        _animationSequence?.Kill();


        _animationSequence = DOTween.Sequence();


        for (int i = 0; i < _frames.Count; i++)
        {
            int frameIndex = i; 
            _animationSequence.AppendCallback(() => _currentImage.sprite = _frames[frameIndex]);
            _animationSequence.AppendInterval(_frameDuration);
        }

        if (_loop)
            _animationSequence.SetLoops(-1);
        if (_destroyAfterPlaying)
            Destroy(gameObject);
    }

    public void StopAnimation()
    {
        _animationSequence?.Kill();
    }

    private void OnDestroy()
    {
        StopAnimation(); 
    }
}
