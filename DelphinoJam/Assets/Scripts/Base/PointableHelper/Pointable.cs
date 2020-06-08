﻿using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Pointable : MonoBehaviour, IPointable
{
	public UnityAction<PointerEventData> PointerEnterAction;
	public UnityAction<PointerEventData> PointerClickAction;
	public UnityAction<PointerEventData> PointerExitAction;
	public UnityAction<PointerEventData> PointerDownAction;
	public UnityAction<PointerEventData> PointerUpAction;


	public virtual void OnPointerEnter(PointerEventData eventData)
	{
		if (PointerEnterAction != null)
			PointerEnterAction.Invoke(eventData);
	}
	public virtual void OnPointerClick(PointerEventData eventData)
	{
		if (PointerClickAction != null)
			PointerClickAction.Invoke(eventData);
	}
	public virtual void OnPointerExit(PointerEventData eventData)
	{
		if (PointerExitAction != null)
			PointerExitAction.Invoke(eventData);
	}
	public virtual void OnPointerDown(PointerEventData eventData)
	{
		if (PointerDownAction != null)
			PointerDownAction.Invoke(eventData);
	}
	public virtual void OnPointerUp(PointerEventData eventData)
	{
		if (PointerUpAction != null)
			PointerUpAction.Invoke(eventData);
	}
}