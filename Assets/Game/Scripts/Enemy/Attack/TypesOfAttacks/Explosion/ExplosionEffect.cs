using UnityEngine;

public class ExplosionEffect : MonoBehaviour
{
    [SerializeField] private GameObject _effect;

    private ExplosiveAttack _explosiveAttack;

    private void Awake()
    {
        _explosiveAttack = GetComponent<ExplosiveAttack>();
    }

    private void OnEnable() => _explosiveAttack.OnPotatoExploded += () => Instantiate(_effect, transform.position, Quaternion.identity);
    private void OnDisable() => _explosiveAttack.OnPotatoExploded -= () => Instantiate(_effect, transform.position, Quaternion.identity);
}
