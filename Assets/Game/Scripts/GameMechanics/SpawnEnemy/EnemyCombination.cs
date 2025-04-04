using UnityEngine;

public class EnemyCombination : MonoBehaviour
{
    [SerializeField] private Enemy _carrot;
    [SerializeField] private Enemy _broccoli;
    [SerializeField] private Enemy _potato;
    [SerializeField] private Enemy _carrotBoss;
    [SerializeField] private Enemy _broccoliBoss;

    private Enemy[] _bosses;
    private Enemy[][] _combination;

    private void Start()
    {
        _combination = new Enemy[8][]
        {
            new Enemy[] { _carrot, _carrot, _carrot},
            new Enemy[] { _broccoli, _potato, _potato},
            new Enemy[] {_broccoli, _broccoli, _potato},
            new Enemy[] {_carrot, _broccoli, _broccoli},
            new Enemy[] {_broccoli, _carrot, _carrot},
            new Enemy[] { _potato, _potato},
            new Enemy[] {_broccoli, _broccoli, _broccoli},
            new Enemy[] { _carrot, _broccoli, _potato }
        };

        _bosses = new Enemy[] { _carrotBoss, _broccoliBoss};
    }
    
    public Enemy[] GetEnemyCombination()
    {
        int combinationNumber = Random.Range(0, _combination.Length);
        return _combination[combinationNumber];
    }

    public Enemy GetBoss()
    {
        return _bosses[Random.Range(0, _bosses.Length)];
    }
}
