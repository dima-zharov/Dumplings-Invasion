using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayersScroller : ScrollController
{
    [SerializeField] private LayerMask _layerMaskForegroundImage;
    [SerializeField] private LayerMask _layerMaskStateImage;
    [SerializeField] private List<Sprite> _foregroundSprites;
    [SerializeField] private Sprite _chosenSprite;
    [SerializeField] private Sprite _unactiveSprite;
    [SerializeField] private Sprite _blockSprite;

    private List<Button> _buttons;
    private List<ElementImagesHandler> _setPlayersScrollerElementsState;
    private List<Image> _foregroundImages;
    private List<Image> _stateImages;
    private int _currentPlayersCount = 3;
    private bool _isProcessing = false;
    private void OnDisable()
    {
        foreach (var button in _buttons)
        {
            if (button != null)
                button.onClick.RemoveAllListeners();
        }
    }

    protected override void Initialize()
    {
        InitializeConcreteElements(out _setPlayersScrollerElementsState);
        _foregroundImages = FindImages(_layerMaskForegroundImage);
        _stateImages = FindImages(_layerMaskStateImage);

        SetImages(_foregroundSprites, _foregroundImages);
        SetupButtons();
        UpdateAllElements();
    }

    private void SetImages(List<Sprite> sprites, List<Image> images)
    {
        int minCount = Mathf.Min(
            _setPlayersScrollerElementsState.Count,
            sprites.Count,
            images.Count
        );

        for (int i = 0; i < minCount; i++)
        {
            _setPlayersScrollerElementsState[i].SetImage(sprites[i], images[i]);
        }
    }


    private void SetupButtons()
    {
        if (_buttons != null)
        {
            foreach (var button in _buttons)
            {
                if (button != null)
                    button.onClick.RemoveAllListeners();
            }
        }

        _buttons = new List<Button>();
        foreach (var element in _scrollElements)
        {
            var button = element.GetComponent<Button>();
            if (button != null)
            {
                _buttons.Add(button);
                button.onClick.AddListener(() => OnButtonClick(button));
            }
        }
    }

    private void OnButtonClick(Button clickedButton)
    {
        if (_isProcessing) return;

        int index = _buttons.IndexOf(clickedButton);

        if (index == -1 || index >= _setPlayersScrollerElementsState.Count || _setPlayersScrollerElementsState[index].IsBlocked)
        {
            return;
        }

        _isProcessing = true;
        try
        {
            UpdateSelection(index);
        }
        finally
        {
            _isProcessing = false;
        }
    }

    private void UpdateSelection(int selectedIndex)
    {

        if (selectedIndex < 0 || selectedIndex >= _setPlayersScrollerElementsState.Count)
        {
            return;
        }


        if (_setPlayersScrollerElementsState[selectedIndex].IsBlocked)
        {
            return;
        }

        for (int i = 0; i < _setPlayersScrollerElementsState.Count; i++)
        {

            if (_setPlayersScrollerElementsState[i] == null ||
                i >= _stateImages.Count ||
                _stateImages[i] == null ||
                i >= _foregroundImages.Count ||
                _foregroundImages[i] == null)
            {
                Debug.LogError($"Ошибка данных элемента {i}");
                continue;
            }

            bool isBlocked = i >= _currentPlayersCount;
            _setPlayersScrollerElementsState[i].ChooseState(
                isBlocked,
                false,
                isBlocked ? _blockSprite : _unactiveSprite,
                _stateImages[i]
            );

            if (i < _foregroundSprites.Count)
            {
                _foregroundImages[i].sprite = _foregroundSprites[i];
            }
        }

        _setPlayersScrollerElementsState[selectedIndex].ChooseState(
            false,
            true,
            _chosenSprite,
            _stateImages[selectedIndex]
        );
    }

    public void IncreasePlayersCount()
    {
        _currentPlayersCount = Mathf.Min(_currentPlayersCount + 1, _setPlayersScrollerElementsState.Count);
        UpdateAllElements();
    }

    private void UpdateAllElements()
    {
        for (int i = 0; i < _setPlayersScrollerElementsState.Count; i++)
        {
            bool isBlocked = i >= _currentPlayersCount;
            _setPlayersScrollerElementsState[i].ChooseState(
                isBlocked,
                false,
                isBlocked ? _blockSprite : _unactiveSprite,
                _stateImages[i]);
        }
    }

    private List<Image> FindImages(LayerMask layerMask)
    {
        List<Image> result = new List<Image>();
        int targetLayer = GetFirstLayerIndex(layerMask);

        foreach (var element in _scrollElements)
        {
            foreach (Transform child in element.GetComponentsInChildren<Transform>(true))
            {
                if (child.gameObject.layer == targetLayer)
                {
                    var image = child.GetComponent<Image>();
                    if (image != null)
                        result.Add(image);
                }
            }
        }
        return result;
    }

    private int GetFirstLayerIndex(int layerMask)
    {
        for (int i = 0; i < 32; i++)
        {
            if ((layerMask & (1 << i)) != 0)
                return i;
        }
        return -1;
    }

}