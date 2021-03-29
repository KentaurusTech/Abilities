using UnityEngine;

[CreateAssetMenu(fileName = nameof(TargetingDatabase), menuName = "Config/Targeting/Database")]
public class TargetingDatabase : ScriptableObject
{
	[SerializeField] private TargetingDefinition[] _targetingDefintions;
}
