using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[System.Serializable]
public class Inventory
{
	public int Size = 0;
	public List<ItemData> Items = new List<ItemData>();


	public void LoadInventory(List<ItemData> itemsToLoad)
	{
		ClearInventory();
		AddItem(itemsToLoad);
	}
	public List<ItemData> ClearInventory()
	{
		List<ItemData> inventoryToReturn = Items.ToList();
		Items.Clear();
		return inventoryToReturn;
	}

	public bool AddItem(ItemData item) 
	{
		if (Items.Count < Size)
		{
			Items.Add(item);
			return true;
		}
		else
		{
			Debug.LogWarning("Inventory full");
			return false;
		}
	}
	public void AddItem(List<ItemData> itemsToAdd)
	{
		foreach (ItemData item in itemsToAdd)
			if (!AddItem(item))
				break;
	}

	public bool RemoveItem(ItemData item) 
	{
		if (Items.Contains(item))
		{
			Items.Remove(item);
			return true;
		}
		else
			return false;
	}
	public void RemoveItem(List<ItemData> itemsToRemove)
	{
		foreach (ItemData item in itemsToRemove)
			RemoveItem(item);
	}
	public ItemData RemoveItemAt(int index = 0)
	{
		if (Items.Count > index)
		{
			ItemData itemData = Items[index];
			Items.RemoveAt(index);
			return itemData;
		}
		else
		{
			Debug.LogWarning("Index outside inventory!");
			return null;
		}
	}
}