using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Sirenix.OdinInspector;

[RequireComponent(typeof(Pointable))]
[RequireComponent(typeof(Draggable))]
public class UiSlot : MonoBehaviour
{
	public ItemData Item;


	[TabGroup("Dependencies")]
	public RectTransform RectTransform;
	[TabGroup("Dependencies")]
	public Image ImageComponent;
	[TabGroup("Dependencies")]
	public Pointable Pointable;
	[TabGroup("Dependencies")]
	public Draggable Draggable;
	[TabGroup("Dependencies")]
	public UiInventory UiInventory;


	private void Awake()
	{
		#region Adds required components

		// Add RectTransform.
		if (!transform.TryGetComponent(out RectTransform))
			RectTransform = gameObject.AddComponent<RectTransform>();

		// If no child?
		if (transform.childCount <= 0)
		{
			// Add a child.
			GameObject iconSlot = new GameObject();
			iconSlot.name = "Icon_Slot";
			iconSlot.transform.parent = transform;
			// Add Image Component.
			ImageComponent = iconSlot.AddComponent<Image>();
		}
		else // Else get Image Component in a first child.
			if (!transform.GetChild(0).TryGetComponent(out ImageComponent))
				transform.GetChild(0).gameObject.AddComponent<Image>();
		if (Item != null)
			ImageComponent.sprite = Item.Icon;

		// Add Pointable and his actions.
		if (!TryGetComponent(out Pointable))
			Pointable = gameObject.AddComponent<Pointable>();

		Pointable.PointerClickAction += PointerClickSlot;
		Pointable.PointerEnterAction += PointerEnterSlot;
		Pointable.PointerExitAction += PointerExitSlot;

		// Add Draggable and his actions.
		if (!TryGetComponent(out Draggable))
			Draggable = gameObject.AddComponent<Draggable>();
		Draggable.BeginDragAction += BeginDragSlot;
		Draggable.DragAction += DragSlot;
		Draggable.EndDragAction += EndDragSlot;

		// Get UiInventory Component in his parent.
		UiInventory = transform.GetComponentInParent<UiInventory>();

		#endregion
	}


	public virtual void PointerClickSlot(PointerEventData eventData)
	{
		
	}
	public virtual void PointerEnterSlot(PointerEventData pointerEventData)
	{
		UiInventory.SetHoveredSlot(this);
	}
	public virtual void PointerExitSlot(PointerEventData pointerEventData)
	{
		UiInventory.SetHoveredSlot(null);
	}
	public virtual void BeginDragSlot(PointerEventData eventData)
	{

	}
	public virtual void DragSlot(PointerEventData eventData)
	{
		// Test Drag
		ImageComponent.rectTransform.anchoredPosition = eventData.pointerCurrentRaycast.screenPosition;
	}
	public virtual void EndDragSlot(PointerEventData eventData)
	{
		SwapSlot();
	}


	// Test Drag
	void SwapSlot()
	{
		ImageComponent.rectTransform.anchoredPosition = Vector2.zero;

		int tempIndex = transform.GetSiblingIndex();
		transform.SetSiblingIndex(UiInventory.transform.GetSiblingIndex());
		UiInventory.transform.SetSiblingIndex(tempIndex);

		PlayerManager.I.GameObjectLoaded.GetComponent<Player>().Inventory.Items.Swap(UiInventory.SlotsList.IndexOf(this), UiInventory.SlotsList.IndexOf(UiInventory.HoveredSlot));
		UiInventory.SlotsList.Swap(UiInventory.SlotsList.IndexOf(this), UiInventory.SlotsList.IndexOf(UiInventory.HoveredSlot));
	}
}