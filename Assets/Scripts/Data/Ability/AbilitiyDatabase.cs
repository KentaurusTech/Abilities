using UnityEngine;

[CreateAssetMenu(fileName = nameof(AbilitiyDatabase), menuName = "Config/Ability/Database")]
public class AbilitiyDatabase : ScriptableObject
{
	[SerializeField] private AbilitiyDefinition[] _abilityDefinitions;
}
