using UnityEngine;
using UnityEngine.UI;

public class ButtonState : MonoBehaviour
{
    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _button.enabled = true;
    }

    public void DisableButton()
    {
        _button.enabled = false;
    }
}
