using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class Bloc : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler, IDragHandler, IDropHandler, IBeginDragHandler, IEndDragHandler
{
	public void OnBeginDrag(PointerEventData eventData)
	{
		GetComponent<BoxCollider>().enabled = false;

		MyDragFunc(eventData);
	}

	public void OnDrag(PointerEventData eventData)
	{
		MyDragFunc(eventData);
	}

	public void OnEndDrag(PointerEventData eventData)
	{
		MyDragFunc(eventData);

		GetComponent<BoxCollider>().enabled = true;
	}
	public void OnDrop(PointerEventData eventData)
	{

	}

	public void OnPointerClick(PointerEventData eventData)
	{

	}

	public void OnPointerDown(PointerEventData eventData)
	{

	}

	public void OnPointerUp(PointerEventData eventData)
	{
		
	}


	void MyDragFunc(PointerEventData eventData)
	{
		if (eventData.pointerCurrentRaycast.gameObject == null)
			return;

		string layerName = LayerMask.LayerToName(eventData.pointerCurrentRaycast.gameObject.layer);
		Debug.Log(layerName);
		Debug.Log(eventData.pointerCurrentRaycast.worldNormal);

		if (layerName == "Terrain")
			transform.position = eventData.pointerCurrentRaycast.worldPosition + new Vector3(0f, transform.localScale.y * 0.5f, 0f);
		else if (layerName == "Bloc")
		{
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

		// Round Funct
		transform.position = new Vector3(Mathf.Round(transform.position.x), Mathf.Round(transform.position.y), Mathf.Round(transform.position.z));
	}
}
