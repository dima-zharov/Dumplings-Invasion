using System.Collections;
using UnityEngine;

public class ErrorPurchase : MonoBehaviour
{
    [SerializeField] private GameObject _errorMessage;
    public void ShowErrorMessage()
    {
        StartCoroutine(ShowErrorPanelCoroutine());
    }

    private IEnumerator ShowErrorPanelCoroutine()
    {
        _errorMessage.SetActive(true);
        yield return new WaitForSeconds(3);
        _errorMessage.SetActive(false);
    }
}
