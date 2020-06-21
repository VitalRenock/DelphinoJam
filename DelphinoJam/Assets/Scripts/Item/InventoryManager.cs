using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InventoryManager : Singleton<InventoryManager>
{
	public PanelUI PlayerInventoryPanelUI;
	public Inventory PlayerInventory;
	public InventoryUI PlayerInventoryUI;

	public PanelUI FactoryPanelUI;
	public Inventory FactoryInputInventory;
	public Inventory FactoryOutputInventory;
	public InventoryUI FactoryInputInventoryUI;
	public InventoryUI FactoryOutputInventoryUI;

	private void Start() => CloseAllPanelsInventory();

	public void ClickedCellAction(ItemData itemData)
	{
		if (itemData != null && PlayerInventory.CanRemoveItem(itemData) && FactoryInputInventory.CanAddItem())
		{
			PlayerInventory.RemoveItem(itemData);
			FactoryInputInventory.AddItem(itemData);
		}
	}

	void CloseAllPanelsInventory()
	{
		PlayerInventoryPanelUI.DisplayPanel(false);
		FactoryPanelUI.DisplayPanel(false);
	}
}