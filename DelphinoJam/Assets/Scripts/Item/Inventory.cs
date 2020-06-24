using Sirenix.OdinInspector;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class Inventory : MonoBehaviour
{
	[DisableInPlayMode] public string Name;
	[DisableInPlayMode] public int MaxSize = 0;
	[DisableInPlayMode] public List<ItemData> Items = new List<ItemData>();
	public UnityEvent onItemAdded;
	public UnityEvent onItemRemoved;
	public Event Event;

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
		if (Items.Count < MaxSize)
		{
			Items.Add(item);
			onItemAdded?.Invoke();
			return true;
		}
		else
		{
			Debug.LogWarning("Inventory full.");
			return false;
		}
	}
	public void AddItem(List<ItemData> itemsToAdd)
	{
		foreach (ItemData item in itemsToAdd)
			if (!AddItem(item))
				break;
	}
	public bool CanAddItem()
	{
		if (Items.Count < MaxSize)
			return true;
		else
			return false;
	}

	public bool RemoveItem(ItemData item) 
	{
		if (Items.Contains(item))
		{
			Items.Remove(item);
			onItemRemoved?.Invoke();
			return true;
		}
		else 
		{
			Debug.LogWarning("Can remove item.");
			return false;
		}
	}
	public void RemoveItem(List<ItemData> itemsToRemove)
	{
		foreach (ItemData item in itemsToRemove)
			RemoveItem(item);
	}
	public bool CanRemoveItem(ItemData item)
	{
		if (Items.Contains(item))
			return true;
		else
			return false;
	}

	public ItemData TakeItemAt(int index = 0)
	{
		if (Items.Count > index)
		{
			ItemData itemData = Items[index];
			Items.RemoveAt(index);
			return itemData;
		}
		else
		{
			Debug.LogWarning("Index outside inventory.");
			return null;
		}
	}

	public void TransferAnItem(ItemData item, Inventory inventoryTarget)
	{
		if (CanRemoveItem(item) && inventoryTarget.CanAddItem())
		{
			RemoveItem(item);
			inventoryTarget.AddItem(item);
		}
	}

	public void SwapItems(ItemData fromItemData, ItemData toItemData)
	{
		Debug.Log("Swap");
		if (!Items.Contains(fromItemData) || !Items.Contains(toItemData))
		{
			Debug.LogWarning("Switch items impossible, an item(s) is not contain in the list");
			return;
		}
		else
		{
			Items.Swap(Items.IndexOf(fromItemData), Items.IndexOf(toItemData));
		}
	}


}