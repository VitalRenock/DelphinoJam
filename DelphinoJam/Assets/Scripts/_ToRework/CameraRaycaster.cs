using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Camera))]
public class CameraRaycaster : MonoBehaviour
{
	public LayerMask AuthorizedLayers;
	public float MaxDistance = 0;
	public bool DebugRayCast = false;
	public List<CameraRaycasterEvent> onHitEvents;

	Camera cameraComponent;

	private void Awake() => cameraComponent = GetComponent<Camera>();

	public void RayCastCamForward()
	{
		Ray rayCam = new Ray(cameraComponent.transform.position, cameraComponent.transform.forward * MaxDistance);
		RaycastHit hitInfo;

		if (Physics.Raycast(rayCam, out hitInfo, MaxDistance, AuthorizedLayers))
			for (int i = 0; i < onHitEvents.Count; i++)
					onHitEvents[i]?.Invoke(hitInfo);

		if (DebugRayCast)
			Debug.DrawRay(rayCam.origin, rayCam.direction, Color.yellow, 2f);
	}
}

[System.Serializable]
public class CameraRaycasterEvent : UnityEvent<RaycastHit> { };