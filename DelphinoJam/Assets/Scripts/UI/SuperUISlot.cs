using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Pointable))]
public class SuperUISlot : MonoBehaviour
{
	public ItemData Item;
	public Pointable Pointable;


	private void Awake()
	{
		Pointable = GetComponent<Pointable>();
		Pointable.PointerClickAction += UseSlot;
	}

	public void InitSlot()
	{

	}
	public void UseSlot(PointerEventData eventData)
	{
		Debug.Log(Item.Name);
	}
	public void ClearSlot()
	{

	}
}