using UnityEngine;

[CreateAssetMenu(fileName = nameof(AbilitiyDefinition), menuName = "Config/Ability/Definition")]
public class AbilitiyDefinition : BaseDefinition
{
	[Targeting, SerializeField] private string _targetingType;
}
