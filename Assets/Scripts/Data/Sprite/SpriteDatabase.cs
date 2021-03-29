using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = nameof(SpriteDatabase), menuName = "Config/Sprite/Database")]
public class SpriteDatabase : ScriptableObject
{
	[Serializable]
	public struct IdToSprite
	{
		public string Id;
		public Sprite Sprite;
	}

	[SerializeField] private IdToSprite[] _icons;

	[NonSerialized] private Dictionary<string, Sprite> _iconDict = new Dictionary<string, Sprite>();

	private void OnEnable()
	{
		LoadSprites(_icons, _iconDict);
	}

	public Sprite GetSprite(SpriteType type, string id)
	{
		var dict = GetDictionary(type);
		if (dict == null)
		{
			return null;
		}

		if (!dict.TryGetValue(id, out var sprite))
		{
			return null;
		}

		return sprite;
	}

	public IDictionary<string, Sprite> GetDictionary(SpriteType type)
	{
		switch (type)
		{
			case SpriteType.Icon: return _iconDict;
			default:
				return null;
		}
	}

	private void LoadSprites(IdToSprite[] datas, Dictionary<string, Sprite> dict)
	{
		foreach (var data in datas)
		{
			dict.Add(data.Id, data.Sprite);
		}
	}
}
