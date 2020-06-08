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
	[ReadOnly] public UiSlot HoveredSlot;

	[TabGroup("Dependencies")]
	[ReadOnly] public GridLayoutGroup GridLayoutGroup;

	private void Awake()
	{
		#region Adds required components

		if (!TryGetComponent(out GridLayoutGroup))
			GridLayoutGroup = gameObject.AddComponent<GridLayoutGroup>();

		// Set Spacing between slots.
		GridLayoutGroup.spacing = Vector2.one * 5;

		#endregion
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
		for (int i = 0; i < inventory.Size; i++)
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