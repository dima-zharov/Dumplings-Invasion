using UnityEngine;
using UnityEngine.UI;

public class ChangeSprite : MonoBehaviour
{
    private Image _image;
    [SerializeField] private Sprite _activeSprite;
    [SerializeField] private Sprite _unActiveSprite;
    [SerializeField] private ButtonTogle _buttonTogle;
    private void Start()
    {
        _image = GetComponent<Image>();
    }
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
