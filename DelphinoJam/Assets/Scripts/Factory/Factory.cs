using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Sirenix.OdinInspector;
using System.Drawing;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Pointable))]
public class Factory : MonoBehaviour
{
	[TabGroup("Energy")]
	public Energy Energy;

	[TabGroup("Inventory")]
	public Inventory InputInventory = new Inventory() { SizeInventory = 10 };
	[TabGroup("Inventory")]
	public Inventory OutputInventory = new Inventory() { SizeInventory = 10 };
	
	[TabGroup("Recipes")]
	public List<RecipeData> RecipesList;
	[TabGroup("Recipes")][ReadOnly]
	public RecipeData RecipeSelected;

	[ReadOnly] public Pointable Pointable;

	private void Awake()
	{
		Pointable = GetComponent<Pointable>();
		Pointable.PointerClickAction += GetItemInPlayerInventory;
	}

	// Temporary
	public void GetItemInPlayerInventory(PointerEventData eventData)
	{
		InputInventory.AddItem(PlayerManager.I.GameObjectLoaded.GetComponent<Player>().Inventory.TakeItemAt());
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

		for (int i = 0; i < InputInventory.Items.Count; i++)
			if (InputInventory.Items[i] == RecipeSelected.InputItem)
			{
				Debugger.I.DebugMessage("Manufacturing");

				if (OutputInventory.AddItem(RecipeSelected.OutputItem))
					InputInventory.RemoveItem(RecipeSelected.InputItem);

				//UIManager.I.UIInventoryFactoryInput.UpdateSlots(InputInventory);
				//UIManager.I.UIInventoryFactoryOutput.UpdateSlots(OutputInventory);
				return;
			}
			else
				Debugger.I.DebugMessage("No item to manufacturing!");
	}
}