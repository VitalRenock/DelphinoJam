using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// REWORK ARCHITECTURE
public class Interactions : MonoBehaviour
{
	public Camera MainCamera;
	public LayerMask InteractionsLayers;
	public float MaxDistance = 0;
	public List<ActionSpecified> SpecifiedActions;

	public void RayCastCamForward()
	{
		Debugger.I.DebugMessage("=> RayCastCamForward");
		Debug.DrawRay(MainCamera.transform.position, MainCamera.transform.forward  * MaxDistance, Color.yellow, 2f);

		// Tir sur les layers autorisés...
		// Pour chaque action spécifiée, on invoque l'event correspondant.
		RaycastHit hitInfo;
		if (Physics.Raycast(MainCamera.transform.position, MainCamera.transform.forward, out hitInfo, MaxDistance, InteractionsLayers))
			for (int i = 0; i < SpecifiedActions.Count; i++)
			{
				// Double comparaison des layers.. TO REWORK...
				if (SpecifiedActions[i].InteractLayers.value == hitInfo.transform.gameObject.layer)
					SpecifiedActions[i].onInteraction.Invoke(hitInfo);
				//if (LayermaskToLayer(SpecifiedActions[i].InteractLayers) == hitInfo.transform.gameObject.layer)
				//	SpecifiedActions[i].onInteraction.Invoke(hitInfo);
			}
	}


	// TO REWORK...
	public static int LayermaskToLayer(LayerMask layerMask)
	{
		int layerNumber = 0;
		int layer = layerMask.value;
		while (layer > 0)
		{
			layer = layer >> 1;
			layerNumber++;
		}
		return layerNumber - 1;
	}
}

[System.Serializable]
public class ActionSpecified
{
	public LayerMask InteractLayers;
	public OnInteractionEvent onInteraction;
}

[System.Serializable]
public class OnInteractionEvent : UnityEvent<RaycastHit> { };