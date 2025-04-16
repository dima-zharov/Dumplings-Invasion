using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

[RequireComponent(typeof(ScrollRect))]
public class SteppedScrollController : MonoBehaviour, IBeginDragHandler, IEndDragHandler
{
    [SerializeField] private float _snapSpeed = 15f;

    private ScrollRect _scroll;
    private RectTransform _content;
    private float[] _elementPositions;
    private bool _isDragging;

    private void Awake()
    {
        _scroll = GetComponent<ScrollRect>();
        _content = _scroll.content;
        CalculatePositions();
    }

    private void CalculatePositions()
    {
        int childCount = _content.childCount;
        _elementPositions = new float[childCount];

        if (childCount == 0) return;

        for (int i = 0; i < childCount; i++)
        {
            RectTransform child = _content.GetChild(i) as RectTransform;
            _elementPositions[i] = _scroll.horizontal
                ? child.anchoredPosition.x / (_content.rect.width - _scroll.viewport.rect.width)
                : 1 - (child.anchoredPosition.y / (_content.rect.height - _scroll.viewport.rect.height));
        }
    }

    public void OnBeginDrag(PointerEventData eventData) => _isDragging = true;
    public void OnEndDrag(PointerEventData eventData) => StartCoroutine(SnapToNearest());


    private IEnumerator SnapToNearest()
    {
        _isDragging = false;

        float currentPos = _scroll.horizontal
            ? _scroll.horizontalNormalizedPosition
            : _scroll.verticalNormalizedPosition;

        int closestIndex = 0;
        float minDistance = float.MaxValue;

        for (int i = 0; i < _elementPositions.Length; i++)
        {
            float distance = Mathf.Abs(currentPos - _elementPositions[i]);
            if (distance < minDistance)
            {
                minDistance = distance;
                closestIndex = i;
            }
        }


        float targetPos = _elementPositions[closestIndex];
        while (Mathf.Abs(currentPos - targetPos) > 0.001f)
        {
            currentPos = Mathf.Lerp(currentPos, targetPos, _snapSpeed * Time.deltaTime);

            if (_scroll.horizontal)
                _scroll.horizontalNormalizedPosition = currentPos;
            else
                _scroll.verticalNormalizedPosition = currentPos;

            yield return null;
        }


        if (_scroll.horizontal)
            _scroll.horizontalNormalizedPosition = targetPos;
        else
            _scroll.verticalNormalizedPosition = targetPos;
    }

    public void UpdatePositions() => CalculatePositions();
}