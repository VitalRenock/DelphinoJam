using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class ItemManager : Singleton<ItemManager>
{
	[ReadOnly] public List<Item> AllItems = new List<Item>();


	public GameObject CreateItem(ItemData itemData)
	{
		GameObject gameObject = Instantiate(itemData.Prefab);

		Item item; 
		gameObject.TryGetComponent(out item);

		if (item == null)
			item = gameObject.AddComponent<Item>();

		item.ItemData = itemData;
		AllItems.Add(item);

		return gameObject;
	}
}