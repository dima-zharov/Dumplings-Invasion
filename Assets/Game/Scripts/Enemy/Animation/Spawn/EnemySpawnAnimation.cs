using DG.Tweening;
using System.Collections;
using UnityEngine;

public class EnemySpawnAnimation : MonoBehaviour
{
    [SerializeField] private float _endSize;
    [SerializeField] private float _duration;

    private FollowPlayer _followPlayer;

    private void Start()
    {
        _followPlayer = GetComponent<FollowPlayer>();

        StartCoroutine(IncreaseSize());
    }

    private IEnumerator IncreaseSize()
    {
        transform.DOScale(_endSize, _duration);
        yield return new WaitForSeconds(_duration);

        _followPlayer.AllowMovement();
    }
}
