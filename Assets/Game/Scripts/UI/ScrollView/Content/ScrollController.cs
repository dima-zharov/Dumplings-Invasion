using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class ScrollController : MonoBehaviour
{
    [SerializeField] private Transform _scrollViewContent;
    [SerializeField] private int _scrollElementsSize;
    [SerializeField] protected GameObject _prefab;
    [SerializeField] protected List<IScrollElement> _scrollActions = new();
    protected List<GameObject> _scrollElements = new();
    private void Start()
    {
        UpdateElements();
    }

    public void UpdateElements()
    {
        if(_scrollElements.Count == 0)
            InitializeElements();
        Initialize();
        ChangeElement();
    }

    private void ChangeElement()
    {
        foreach (IScrollElement action in _scrollActions)
            action.MakeElementAction();
    }

    private void InitializeElements()
    {
        for (int i = 0; i < _scrollElementsSize; i++)
        {
            _scrollElements.Add(Instantiate(_prefab, _scrollViewContent));
        }

        _scrollActions = FindObjectsOfType<MonoBehaviour>()
                     .OfType<IScrollElement>()
                     .ToList();
    }


    protected virtual void Initialize() { }
    protected void InitializeConcreteElements<T>(out List<T> someActions) where T : MonoBehaviour, IScrollElement
    {
        someActions = _scrollActions.OfType<T>().ToList();
        someActions.Reverse();
        _scrollElements?.Clear();
        _scrollElements.AddRange(someActions.Select(x => x.gameObject));
    }


    protected void ChangeElementsSize(int size) => _scrollElementsSize = size;

}
