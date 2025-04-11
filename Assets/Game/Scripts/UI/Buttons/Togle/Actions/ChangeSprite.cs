using System;
using UnityEngine;
using UnityEngine.UI;

public class ChangeSprite : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private Sprite _activeSprite;
    [SerializeField] private Sprite _unActiveSprite;
    [SerializeField] private ButtonTogle _buttonTogle;

    private void SetActiveSprite()
    {
        _image.sprite = _activeSprite;
    }
    private void SetUnActiveSprite()
    {
        _image.sprite = _unActiveSprite;
    }

    public void ChangeSpriteState()
    {
        _buttonTogle.TogleState(SetUnActiveSprite, SetActiveSprite);
    }
}
