using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayersScroller : ScrollController
{
    public int SelectedPlayerNumber { get; private set; } = 2;
    [SerializeField] private PlayerChoise _playerChoise;
    [Header("Elements Data")]
    [Space]
    [Header("Layers")]
    [Space]
    [SerializeField] private LayerMask _layerMaskForegroundImage;
    [SerializeField] private LayerMask _layerMaskStateImage;
    [Space]
    [Header("Description")]
    [SerializeField] private TextMeshProUGUI _descriptionTextLabel;
    [SerializeField] private List<string> _descriptions;
    [Space]
    [Header("Sprites")]
    [SerializeField] private List<Sprite> _foregroundSprites;
    [SerializeField] private Sprite _chosenSprite;
    [SerializeField] private Sprite _unactiveSprite;
    [SerializeField] private Sprite _blockSprite;

    private List<Button> _buttons;
    private List<ElementImagesHandler> _handlersPlayersScrollerElementsState;
    private List<ElementDescriptionTextChanger> _changersElementDescriptionText;
    private List<ChoiseSoundPlayer> _choicesSoundPlayers;
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
        InitializeConcreteElements(out _handlersPlayersScrollerElementsState);
        InitializeConcreteElements(out _changersElementDescriptionText);
        InitializeConcreteElements(out _choicesSoundPlayers);
        _foregroundImages = FindImages(_layerMaskForegroundImage);
        _stateImages = FindImages(_layerMaskStateImage);

        SetImages(_foregroundSprites, _foregroundImages);
        SetData();
        SetupButtons();
        UpdateAllElements();
    }

    private void SetImages(List<Sprite> sprites, List<Image> images)
    {
        int minCount = Mathf.Min(
            _handlersPlayersScrollerElementsState.Count,
            sprites.Count,
            images.Count
        );

        for (int i = 0; i < minCount; i++)
        {
            _handlersPlayersScrollerElementsState[i].SetImage(sprites[i], images[i]);
        }
    }

    private void ChangeDataToElement()
    {
        _handlersPlayersScrollerElementsState[SelectedPlayerNumber].ChooseState(false, true, _chosenSprite, _stateImages[SelectedPlayerNumber]);
        _descriptionTextLabel.text = _descriptions[SelectedPlayerNumber];
    }

    private void SetData()
    {
        for (int i = 0; i < _choicesSoundPlayers.Count; i++)
        {
            _choicesSoundPlayers[i].InitializeData(_handlersPlayersScrollerElementsState[i]);
            _changersElementDescriptionText[i].SetElementText(_descriptions[i]);
        }
        ChangeDataToElement();
        _playerChoise.ActivatePlayer(SelectedPlayerNumber);
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


        _isProcessing = true;
        try
        {
            UpdateSelection(index);
            _choicesSoundPlayers[index].PlayElementChoisenSound(_handlersPlayersScrollerElementsState[index]);
            SelectedPlayerNumber = index;
            _descriptionTextLabel.text = _descriptions[index];
            _playerChoise.ActivatePlayer(SelectedPlayerNumber);
        }
        finally
        {
            _isProcessing = false;
        }
    }

    private void UpdateSelection(int selectedIndex)
    {

        if (selectedIndex < 0 || selectedIndex >= _handlersPlayersScrollerElementsState.Count)
        {
            return;
        }

        if (_handlersPlayersScrollerElementsState[selectedIndex].IsBlocked)
        {
            return;
        }

        for (int i = 0; i < _handlersPlayersScrollerElementsState.Count; i++)
        {

            if (_handlersPlayersScrollerElementsState[i] == null ||
                i >= _stateImages.Count ||
                _stateImages[i] == null ||
                i >= _foregroundImages.Count ||
                _foregroundImages[i] == null)
            {
                continue;
            }

            bool isBlocked = i >= _currentPlayersCount;
            _handlersPlayersScrollerElementsState[i].ChooseState(
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

        _handlersPlayersScrollerElementsState[selectedIndex].ChooseState(
            false,
            true,
            _chosenSprite,
            _stateImages[selectedIndex]
        );

    }

    public void IncreasePlayersCount()
    {
        _currentPlayersCount = Mathf.Min(_currentPlayersCount + 1, _handlersPlayersScrollerElementsState.Count);
        UpdateAllElements();
    }


    private void UpdateAllElements()
    {
        for (int i = 0; i < _handlersPlayersScrollerElementsState.Count; i++)
        {
            _changersElementDescriptionText[i].SetElementText(_descriptions[i]);
            if(!_handlersPlayersScrollerElementsState[i].IsActive)
            {
                bool isBlocked = i >= _currentPlayersCount;
                _handlersPlayersScrollerElementsState[i].ChooseState(
                    isBlocked,
                    false,
                    isBlocked ? _blockSprite : _unactiveSprite,
                    _stateImages[i]);
            }
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