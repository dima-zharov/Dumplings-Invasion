using System.Collections;
using UnityEngine;

public class ActivateUIElements : MonoBehaviour
{
    const float AWAIT_TIME = 2.2f;

    [SerializeField] GameObject[] _elements;
    [SerializeField] LoadLevel _loadLevel;

    private void OnEnable()
    {
        _loadLevel.OnLevelLoaded += Activate;
    }

    private void OnDisable()
    {
        _loadLevel.OnLevelLoaded -= Activate;
    }

    private IEnumerator ActivateUIElementsCoroutine()
    {
        yield return new WaitForSeconds(AWAIT_TIME);
        
        for(int i = 0; i < _elements.Length; i++)
        {
            _elements[i].SetActive(true);
        }
    } 
    private void Activate() => StartCoroutine(ActivateUIElementsCoroutine());

}
