using UnityEngine;

public class EnemyStartSettings : MonoBehaviour
{
    [SerializeField] private Levels _levels;

    public void SetSettings(Enemy enemy)
    {
        PushPlayer pushPlayer = enemy.GetComponent<PushPlayer>();
        DefenceAbility defence = enemy.GetComponent<DefenceAbility>();

        float upgrade = (float)_levels.CurrentLevel / 10;

        if (pushPlayer != null && defence != null)
        {
            pushPlayer.SetStartForce(upgrade);
            defence.SetDefence(upgrade);
        }

    }
}
