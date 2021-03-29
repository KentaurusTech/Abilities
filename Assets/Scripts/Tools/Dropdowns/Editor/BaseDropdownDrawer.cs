using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class BaseDropdownDrawer<T> : PropertyDrawer where T : BaseDefinition
{
	private string[] _definitionIds = new string[0];
	private string[] _databaseLocations = new string[]
	{
		"Assets/Database/Definitions"
	};
	public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
	{
		UpdateDefinitionList();

		int indexValue = ArrayUtility.FindIndex(_definitionIds, Is);
		indexValue = Mathf.Max(indexValue, 0);
		indexValue = EditorGUI.Popup(position, label.text, indexValue, _definitionIds);

		property.stringValue = _definitionIds[indexValue];

		bool Is(string id)
		{
			return property.stringValue == id;
		}
	}

	private void UpdateDefinitionList()
	{
		var guiIds = AssetDatabase.FindAssets($"t:{typeof(T).Name}", _databaseLocations);

		// Adding non to the length
		if (guiIds.Length + 1 == _definitionIds.Length)
		{
			return;
		}

		List<string> definitionIds = new List<string>();
		definitionIds.Add("None");

		guiIds.ToList()
			.ForEach((guiId) =>
			{
				var assetPath = AssetDatabase.GUIDToAssetPath(guiId);
				var p = AssetDatabase.LoadAssetAtPath<BaseDefinition>(assetPath);
				definitionIds.Add(p.Id);
			});

		_definitionIds = definitionIds.ToArray();
	}
}
