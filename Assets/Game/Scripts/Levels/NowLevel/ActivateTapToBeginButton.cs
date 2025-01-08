using System.Collections;
using UnityEngine;

public class ActivateTapToBeginButton : MonoBehaviour
{
    const float AWAIT_TIME = 2.2f;

    [SerializeField] GameObject _tapToBeginButton;
    [SerializeField] LoadLevel _loadLevel;

    private void OnEnable()
    {
        _loadLevel.OnLevelLoaded += ActivateTapToBeginButtonMethod;
    }

    private void OnDisable()
    {
        _loadLevel.OnLevelLoaded -= ActivateTapToBeginButtonMethod;
    }

    private IEnumerator ActivateTapToBeginButtonCoroutine()
    {
        yield return new WaitForSeconds(AWAIT_TIME);
        _tapToBeginButton.SetActive(true);
    } 
    private void ActivateTapToBeginButtonMethod() => StartCoroutine(ActivateTapToBeginButtonCoroutine());

}
