using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class PlayersScroller : ScrollController
{
    private List<SetElementState> _setPlayersScrollerElementsState;
    [SerializeField] private LayerMask _layerElementBackground;
    [SerializeField] private List<Sprite> _sprites;
    [SerializeField] private List<Image> _images;

    protected override void Initialize()
    {
        InitializeConcreteElements(out _setPlayersScrollerElementsState);
        _images = _scrollElements.SelectMany(go =>
        go.GetComponentsInChildren<Transform>(true)
          .Where(child => child.name == _layerElementBackground.value.ToString()) 
          .SelectMany(child => child.GetComponents<Image>())).ToList();
        SetImages();
    }

    private void SetImages()
    {
        int minCount = Mathf.Min(
            _setPlayersScrollerElementsState.Count,
            _sprites.Count,
            _images.Count
        );

        Enumerable.Range(0, minCount)
            .ToList()
            .ForEach(i => _setPlayersScrollerElementsState[i]
                .SetImage(_sprites[i], _images[i]));
    }
}


