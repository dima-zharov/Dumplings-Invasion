using System.Collections;
using DG.Tweening;
using UnityEngine;

public class TutorialSpawnEnemyAnimation : MonoBehaviour
{
    [SerializeField] private float _endSize;
    [SerializeField] private float _duration;

    private TutorialFollowPlayer _followPlayer;

    private void Start()
    {
        _followPlayer = GetComponent<TutorialFollowPlayer>();

        StartCoroutine(IncreaseSize());
    }

    private IEnumerator IncreaseSize()
    {
        transform.DOScale(_endSize, _duration);
        yield return new WaitForSeconds(_duration);

        _followPlayer.AllowMovement();
    }
}
