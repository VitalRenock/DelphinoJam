using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Camera))]
public class CamInteraction : MonoBehaviour
{
	public LayerMask AuthorizedLayers;
	public float MaxDistance = 0;
	public bool DebugRayCast = false;
	public List<ActionSpecified> SpecifiedActions;

	Camera cameraComponent;

	private void Awake() => cameraComponent = GetComponent<Camera>();

	public void RayCastCamForward()
	{
		RaycastHit hitInfo;
		if (Physics.Raycast(cameraComponent.transform.position, cameraComponent.transform.forward, out hitInfo, MaxDistance, AuthorizedLayers))
		{
			for (int i = 0; i < SpecifiedActions.Count; i++)
					SpecifiedActions[i].onHit?.Invoke(hitInfo);
		}
		Debug.DrawRay(cameraComponent.transform.position, cameraComponent.transform.forward  * MaxDistance, Color.yellow, 2f);
	}
}

[System.Serializable]
public class ActionSpecified
{
	public string ActionName;
	public CamRaycastForwardEvent onHit;
}

[System.Serializable]
public class CamRaycastForwardEvent : UnityEvent<RaycastHit> { };