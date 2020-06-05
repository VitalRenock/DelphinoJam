using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

[RequireComponent(typeof(Pointable))]
[RequireComponent(typeof(Draggable))]
public class Bloc : MonoBehaviour
{
	[ReadOnly] public BoxCollider BoxCollider;
	[ReadOnly] public Pointable Interactable;
	[ReadOnly] public Draggable Draggable;

	public void Awake()
	{
		BoxCollider = GetComponent<BoxCollider>();
		Interactable = GetComponent<Pointable>();
		Draggable = GetComponent<Draggable>();

		// Temporary
		Draggable.BeginDragAction += SwitchBoxColliderActivation;
		Draggable.DragAction += DragFunc;
		Draggable.EndDragAction += SwitchBoxColliderActivation;
	}

	#region Temporary

	void SwitchBoxColliderActivation(PointerEventData eventData)
	{
		if (!BoxCollider.enabled)
			BoxCollider.enabled = true;
		else
			BoxCollider.enabled = false;
	}
	void DragFunc(PointerEventData eventData)
	{
		if (eventData.pointerCurrentRaycast.gameObject == null)
			return;

		string layerName = LayerMask.LayerToName(eventData.pointerCurrentRaycast.gameObject.layer);

		if (layerName == "Terrain")
			transform.position = eventData.pointerCurrentRaycast.worldPosition + (eventData.pointerCurrentRaycast.worldNormal * (transform.localScale.y * 0.5f));

		else if (layerName == "Bloc")
		{
			// Snap Func
			if (eventData.pointerCurrentRaycast.worldNormal == Vector3.right)
				transform.position = eventData.pointerCurrentRaycast.worldPosition + new Vector3(transform.localScale.x * 0.5f, 0f, 0f);
			else if (eventData.pointerCurrentRaycast.worldNormal == -Vector3.right)
				transform.position = eventData.pointerCurrentRaycast.worldPosition + new Vector3(-transform.localScale.x * 0.5f, 0f, 0f);
			else if (eventData.pointerCurrentRaycast.worldNormal == Vector3.up)
				transform.position = eventData.pointerCurrentRaycast.worldPosition + new Vector3(0f, transform.localScale.y * 0.5f, 0f);
			else if (eventData.pointerCurrentRaycast.worldNormal == -Vector3.up)
				transform.position = eventData.pointerCurrentRaycast.worldPosition + new Vector3(0f, -transform.localScale.y * 0.5f, 0f);
			else if(eventData.pointerCurrentRaycast.worldNormal == Vector3.forward)
				transform.position = eventData.pointerCurrentRaycast.worldPosition + new Vector3(0f, 0f, transform.localScale.z * 0.5f);
			else if (eventData.pointerCurrentRaycast.worldNormal == -Vector3.forward)
				transform.position = eventData.pointerCurrentRaycast.worldPosition + new Vector3(0f, 0f, -transform.localScale.z * 0.5f);
		}

		// Round Func
		transform.position = transform.position.Round();
	}

	#endregion
}