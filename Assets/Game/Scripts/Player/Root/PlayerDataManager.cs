using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerDataManager : MonoBehaviour
{
    [SerializeField] private PlayerForce _force;
    [SerializeField] private DefenceAbility _defence;

    public void SetPlayerData(float pushForce, float defenceIndex)
    {
        _force.Init(pushForce);
        _defence.Init(defenceIndex);
    }
}
