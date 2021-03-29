using UnityEngine;

[CreateAssetMenu(fileName = nameof(GlobalDatabase), menuName = "Config/Global/Database")]
public class GlobalDatabase : ScriptableObject
{
	[SerializeField] private TargetingDatabase _targetDatabase;
	[SerializeField] private AbilitiyDatabase _abilityDatabase;
}
