using UnityEngine;

public class PotatoExplosion : MonoBehaviour
{
    private ExplosiveAttack _explosiveAttack;

    private void Awake()
    {
        _explosiveAttack = GetComponent<ExplosiveAttack>();
    }

    private void OnEnable() => _explosiveAttack.OnPotatoExploded += () => Destroy(gameObject);

    private void OnDisable() => _explosiveAttack.OnPotatoExploded -= () => Destroy(gameObject);
}
