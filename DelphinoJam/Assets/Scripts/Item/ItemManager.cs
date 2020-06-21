using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using System.Linq;

public class ItemManager : Singleton<ItemManager>
{
	[FoldoutGroup("Debug")]
	[ReadOnly] public List<Item> AllItems = new List<Item>();

	private void Awake()
	{
		FindAllItems();
		RegisterActionOfAllItems();
	}

	public Item CreateItem(ItemData itemData)
	{
		GameObject gameObject = Instantiate(itemData.Prefab);

		Item item = gameObject.GetOrAddComponent<Item>(); 
		item.ItemData = itemData;
		AllItems.Add(item);

		return item;
	}
	public Item CreateItem(ItemData itemData, Vector3 position)
	{
		Item item = CreateItem(itemData);
		item.transform.position = position;

		return item;
	}
	public Item CreateItem(ItemData itemData, Vector3 position, Vector3 rotation)
	{
		Item item = CreateItem(itemData, position);
		item.gameObject.transform.eulerAngles = rotation;

		return item;
	}

	void FindAllItems() => AllItems = FindObjectsOfType<Item>().ToList();

	void RegisterActionOfItem(Item item) => item.onItemClicked.AddListener(ItemActionClicked);
	void RegisterActionOfAllItems()
	{
		foreach (Item item in AllItems)
			RegisterActionOfItem(item);
	}

	public void ItemActionClicked(Item item)
	{
		bool isGived = InventoryManager.I.PlayerInventory.AddItem(item.ItemData);
		if (isGived)
			item.DestroyItem();
	}
}