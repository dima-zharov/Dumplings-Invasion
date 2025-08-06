using UnityEngine;

public class ElementDescriptionTextChanger : MonoBehaviour, IScrollElement
{
    private string _descriptionText;

    public void MakeElementAction()
    {
        SetElementText(_descriptionText);
    }

    public void SetElementText(string text)
    {
        _descriptionText = text;
    }
}
