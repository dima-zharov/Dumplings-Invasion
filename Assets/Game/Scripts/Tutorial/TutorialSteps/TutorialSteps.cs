using UnityEngine;

[CreateAssetMenu(menuName = "Tutorial/Step")]
public class TutorialStep : ScriptableObject
{
    public string InstructionText;
    public Sprite GifHint;
    public GameObject EnemyPrefab;
}
