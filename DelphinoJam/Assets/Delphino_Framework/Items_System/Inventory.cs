using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class Inventory : MonoBehaviour
{

	[TabGroup("Options")] [DisableInPlayMode] public string Name;
	[TabGroup("Options")] [DisableInPlayMode] public int MaxSize = 0;

	[TabGroup("Items list")] [DisableInPlayMode] public List<ItemData> Items = new List<ItemData>();

	[TabGroup("Events")] [DisableInPlayMode] public ItemDataEvent onItemAdded;
	[TabGroup("Events")] [DisableInPlayMode] public ItemDataEvent onItemRemoved;

	/// <summary>
	/// Return a bool.
	/// </summary>
	/// <returns>return 'true' if 'Items' list is not full else return 'false'.</returns>
	public bool CanAddItem()
	{
		if (Items.Count < MaxSize)
			return true;
		else
			return false;
	}

	/// <summary>
	/// Add an item if Items list is not full.
	/// </summary>
	/// <param name="itemDataToAdd"></param>
	/// <returns>return true if item is added else return false if Items list is full.</returns>
	public bool AddItem(ItemData itemDataToAdd)
	{

		if (Items.Count < MaxSize)
		{
			Items.Add(itemDataToAdd);
			onItemAdded?.Invoke(itemDataToAdd);
			return true;
		}
		else
		{
			Debug.LogWarning("Inventory full.");
			return false;
		}
	}

	/// <summary>
	/// Add a list of itemData at the end of the Items list, 
	/// stop if 'Items' list is full.
	/// </summary>
	/// <param name="itemDatasToAdd"></param>
	public void AddItems(List<ItemData> itemDatasToAdd)
	{
		foreach (ItemData item in itemDatasToAdd)
			if (!AddItem(item))
				break;
	}


	public bool CanRemoveItem(ItemData itemDataToCheck)
	{
		if (Items.Contains(itemDataToCheck))
			return true;
		else
			return false;
	}
	public bool RemoveItem(ItemData itemDataToRemove)
	{
		if (Items.Contains(itemDataToRemove))
		{
			Items.Remove(itemDataToRemove);
			onItemRemoved?.Invoke(itemDataToRemove);
			return true;
		}
		else
		{
			Debug.LogWarning("Can remove item.");
			return false;
		}
	}
	public void RemoveItems(List<ItemData> itemDatasToRemove)
	{
		foreach (ItemData item in itemDatasToRemove)
			if (!RemoveItem(item))
				break;
	}


	/// <summary>
	/// Clear all items of 'Items' list.
	/// </summary>
	public void ClearItems()
	{
		Items.Clear();
	}


	/// <summary>
	/// Clear and load a new list of itemData.
	/// </summary>
	/// <param name = "itemDatasToLoad" ></ param >
	public void LoadInventory(List<ItemData> itemDatasToLoad)
	{
		ClearItems();
		AddItems(itemDatasToLoad);
	}



	public ItemData TakeItemAt(int index = 0)
	{
		if (Items.Count > index)
		{
			ItemData itemData = Items[index];
			Items.RemoveAt(index);
			onItemRemoved?.Invoke(itemData);
			return itemData;
		}
		else
		{
			Debug.LogWarning("Index outside inventory.");
			return null;
		}
	}
	public void TransferAnItem(ItemData itemDataToTransfer, Inventory inventoryTarget)
	{
		if (CanRemoveItem(itemDataToTransfer) && inventoryTarget.CanAddItem())
		{
			RemoveItem(itemDataToTransfer);
			inventoryTarget.AddItem(itemDataToTransfer);
		}
	}
	public void SwapItems(ItemData fromItemData, ItemData toItemData)
	{
		if (!Items.Contains(fromItemData) || !Items.Contains(toItemData))
		{
			Debug.LogWarning("Switch items impossible, an item(s) is not contain in the list");
			return;
		}
		else
			Items.Swap(Items.IndexOf(fromItemData), Items.IndexOf(toItemData));
	}
}