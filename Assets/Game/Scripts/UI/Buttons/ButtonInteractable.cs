using UnityEngine;
using UnityEngine.UI;

public class ButtonIntaracteble : MonoBehaviour
{
    [SerializeField] private Button _myButton;

    public void DisableButton()
    {
        _myButton.interactable = false;
    }

    public void EnableButton()
    {
        _myButton.interactable = true;
    }

}
