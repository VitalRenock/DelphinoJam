using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperUIInventory : MonoBehaviour
{
	public GameObject PrefabForSlot;
	[ReadOnly] public List<GameObject> SlotsList;


	void GenerateSlots(Inventory inventory)
	{
		for (int i = 0; i < inventory.Size; i++)
			SlotsList.Add(Instantiate(PrefabForSlot, transform));
	}
	public void ClearAllSlots()
	{
		for (int i = 0; i < SlotsList.Count; i++)
			Destroy(SlotsList[i]);

		SlotsList.Clear();
	}
	public void UpdateSlots(Inventory inventory)
	{
		if (inventory == null)
		{
			Debug.LogError("Inventory null!");
			return;
		}

		ClearAllSlots();
		GenerateSlots(inventory);

		for (int i = 0; i < inventory.Items.Count; i++)
		{
			SuperUISlot currentSlot = SlotsList[i].GetComponent<SuperUISlot>();
			currentSlot.Item = inventory.Items[i];
			currentSlot.InitSlot();
		}
	}
}