using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Sirenix.OdinInspector;
using UnityEngine.EventSystems;


public class Factory : MonoBehaviour
{
	[TabGroup("Energy")]
	public Energy Energy;


	[TabGroup("Inventory")] public Inventory InventoryInput;
	[TabGroup("Inventory")] public Inventory InventoryOutput;
	[TabGroup("Inventory")] public PanelUI PanelFactoryUI;
	
	[TabGroup("Recipes")]
	public List<RecipeData> RecipesList;
	[TabGroup("Recipes")][ReadOnly]
	public RecipeData RecipeSelected;

	[ReadOnly] public Pointable Pointable;


	private void Reset()
	{
		List<Inventory> inventories = gameObject.GetOrAddComponents<Inventory>(2);
		InventoryInput = inventories[0];
		InventoryOutput = inventories[1];
		InventoryInput.Name = "Input Inventory";
		InventoryOutput.Name = "Output Inventory";

		Pointable = gameObject.GetOrAddComponent<Pointable>();
	}


	public void FactoryStartStop(PointerEventData eventData)
	{
		Debugger.I.DebugMessage("=> FactoryStartStop");

		if (Energy.IsOn == false)
			StartFactory();
		else
			StopFactory();
	}
	void StartFactory()
	{
		Debugger.I.DebugMessage("=> StartFactory");

		TimeManager.I.onMasterTick.AddListener(Energy.Cycle);
		Energy.onCycle.AddListener(delegate { Manufacturing(); });
		Energy.onOverConsumption.AddListener(StopFactory);
		Energy.IsOn = true;

		//UIManager.I.FactoryButtonCraft.GetComponent<Image>().color = Color.green;
	}
	void StopFactory()
	{
		Debugger.I.DebugMessage("=> StopFactory");

		TimeManager.I.onMasterTick.RemoveAllListeners();
		Energy.onCycle.RemoveAllListeners();
		Energy.onOverConsumption.RemoveAllListeners();
		Energy.IsOn = false;

		//UIManager.I.FactoryButtonCraft.GetComponent<Image>().color = Color.red;
	}

	public void Manufacturing()
	{
		Debugger.I.DebugMessage("=> Manufacturing");

		if (!Energy.IsOn)
			StopFactory();

		for (int i = 0; i < InventoryInput.Items.Count; i++)
			if (InventoryInput.Items[i] == RecipeSelected.InputItem)
			{
				Debugger.I.DebugMessage("Manufacturing");

				if (InventoryOutput.AddItem(RecipeSelected.OutputItem))
					InventoryInput.RemoveItem(RecipeSelected.InputItem);

				//UIManager.I.UIInventoryFactoryInput.UpdateSlots(InputInventory);
				//UIManager.I.UIInventoryFactoryOutput.UpdateSlots(OutputInventory);
				return;
			}
			else
				Debugger.I.DebugMessage("No item to manufacturing!");
	}


	//public void GetItemInPlayerInventory()
	//{
	//	ItemData itemData = FindObjectOfType<Player>().Inventory.TakeItemAt();
	//	if (itemData)
	//	{
	//		InventoryInput.AddItem(itemData);

	//		InventoryUI[] inventoryUIs = FindObjectsOfType<InventoryUI>();
	//		foreach (InventoryUI inventoryUI in inventoryUIs)
	//			inventoryUI.UpdateCells();
	//	}
	//}
}