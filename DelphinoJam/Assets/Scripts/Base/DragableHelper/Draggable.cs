using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IDraggable
{
	public UnityAction<PointerEventData> BeginDragAction;
	public UnityAction<PointerEventData> DragAction;
	public UnityAction<PointerEventData> EndDragAction;

	public void OnBeginDrag(PointerEventData eventData)
	{
		if (BeginDragAction != null)
			BeginDragAction.Invoke(eventData);
	}

	public void OnDrag(PointerEventData eventData)
	{
		if (DragAction != null)
			DragAction.Invoke(eventData);
	}

	public void OnEndDrag(PointerEventData eventData)
	{
		if (EndDragAction != null)
			EndDragAction.Invoke(eventData);
	}
}