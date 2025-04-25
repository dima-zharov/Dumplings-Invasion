using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(ScrollRect))]
public class SteppedScrollController : MonoBehaviour, IBeginDragHandler, IEndDragHandler
{
    [SerializeField] private RectTransform contentPanel; 
    [SerializeField] private float snapSpeed = 10f;
    [SerializeField] private bool isHorizontal = true; 

    private ScrollRect _scrollRect;
    private bool _isDragging = false;
    private int _currentItemIndex = 0;
    private float[] _itemPositions;

    private void Start()
    {
        _scrollRect = GetComponent<ScrollRect>();
        UpdateItemPositions();
    }
    public void UpdateItemPositions()
    {
        if (contentPanel == null || contentPanel.childCount == 0)
        {
            Debug.LogError("ContentPanel не назначен или пуст!");
            return;
        }

        _itemPositions = new float[contentPanel.childCount];
        float step = 1f / (contentPanel.childCount - 1);

        for (int i = 0; i < _itemPositions.Length; i++)
        {
            _itemPositions[i] = i * step;
        }
    }

    private void Update()
    {
        if (!_isDragging && _itemPositions != null && _itemPositions.Length > 0)
        {
            float currentPos = isHorizontal
                ? _scrollRect.horizontalNormalizedPosition
                : _scrollRect.verticalNormalizedPosition;

            float newPos = Mathf.Lerp(
                currentPos,
                _itemPositions[_currentItemIndex],
                snapSpeed * Time.deltaTime
            );

            if (isHorizontal)
                _scrollRect.horizontalNormalizedPosition = newPos;
            else
                _scrollRect.verticalNormalizedPosition = newPos;
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _isDragging = true;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _isDragging = false;
        SnapToClosestItem();
    }

    private void SnapToClosestItem()
    {
        if (_itemPositions == null || _itemPositions.Length == 0)
            return;

        float currentPos = isHorizontal
            ? _scrollRect.horizontalNormalizedPosition
            : _scrollRect.verticalNormalizedPosition;

        float minDistance = float.MaxValue;
        int closestIndex = 0;

        for (int i = 0; i < _itemPositions.Length; i++)
        {
            float distance = Mathf.Abs(currentPos - _itemPositions[i]);
            if (distance < minDistance)
            {
                minDistance = distance;
                closestIndex = i;
            }
        }

        _currentItemIndex = closestIndex;
    }


    public void GoToStep(int stepIndex)
    {
        if (_itemPositions != null && stepIndex >= 0 && stepIndex < _itemPositions.Length)
        {
            _currentItemIndex = stepIndex;
        }
    }
}