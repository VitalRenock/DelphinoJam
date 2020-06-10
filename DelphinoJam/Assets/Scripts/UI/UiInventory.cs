using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(GridLayoutGroup))]
public class UiInventory : MonoBehaviour
{
	[InfoBox("Work with GridLayoutGroup", InfoMessageType = InfoMessageType.None)]

	[TabGroup("Slots")]
	[ReadOnly] public List<UiSlot> SlotsList;
	[TabGroup("Slots")]
	[ReadOnly] public UiSlot HoveredSlot;

	[FoldoutGroup("Dependencies")]
	[ReadOnly] public GridLayoutGroup GridLayoutGroup;

	private void Awake() => GridLayoutGroup = gameObject.GetOrAddComponent<GridLayoutGroup>();


	// !!! Temporary
	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Tab))
			UpdateSlots(FindObjectOfType<Player>().Inventory);
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
	}
	void GenerateSlots(Inventory inventory)
	{
		for (int i = 0; i < inventory.SizeInventory; i++)
		{
			GameObject generateSlot = new GameObject();
			generateSlot.name = "Slot " + i.ToString();
			generateSlot.transform.parent = transform;
			UiSlot uiSlot = generateSlot.AddComponent<UiSlot>();
			SlotsList.Add(uiSlot);
			if (i < inventory.Items.Count)
				uiSlot.Item = inventory.Items[i];
		}
	}
	public void ClearAllSlots()
	{
		for (int i = 0; i < SlotsList.Count; i++)
			Destroy(SlotsList[i].gameObject);

		SlotsList.Clear();
	}
	public void SetHoveredSlot(UiSlot slotHovered)
	{
		if (SlotsList.Contains(slotHovered))
			HoveredSlot = slotHovered;
	}
}