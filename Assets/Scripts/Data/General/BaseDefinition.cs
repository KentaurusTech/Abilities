using UnityEngine;

public class BaseDefinition : ScriptableObject, IIdentifiable
{
	public string Id => name;
}
