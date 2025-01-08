using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombination : MonoBehaviour
{
    [SerializeField] private Enemy _carrot;
    [SerializeField] private Enemy _broccoli;
    [SerializeField] private Enemy _potato;

    private Enemy[][] _combination;

    private void Start()
    {
        _combination = new Enemy[3][]
        {
            new Enemy[] { _carrot, _carrot, _carrot, _carrot },
            new Enemy[] { _broccoli, _potato, _potato, _carrot},
            new Enemy[] {_broccoli, _broccoli, _broccoli}
        };
    }
    
    public Enemy[] GetEnemyCombination()
    {
        int combinationNumber = Random.Range(0, _combination.Length);
        return _combination[combinationNumber];
    }
}
