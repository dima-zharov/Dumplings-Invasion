using UnityEngine;
using UnityEngine.Video;

[CreateAssetMenu(menuName = "Tutorial/Step")]
public class TutorialStep : ScriptableObject
{
    public string HelpText;
    public string InstructionText;
    public GameObject EnemyPrefab;
}
