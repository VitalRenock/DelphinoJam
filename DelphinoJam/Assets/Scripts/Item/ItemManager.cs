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
	public GameObject CreateItem(ItemData itemData, Vector3 position)
	{
		GameObject gameObject = CreateItem(itemData);
		gameObject.transform.position = position;

		return gameObject;
	}
	public GameObject CreateItem(ItemData itemData, Vector3 position, Vector3 rotation)
	{
		GameObject gameObject = CreateItem(itemData, position);
		gameObject.transform.eulerAngles = rotation;

		return gameObject;
	}
}