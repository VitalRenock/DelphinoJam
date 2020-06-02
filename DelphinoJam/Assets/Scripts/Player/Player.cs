using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using System;
using UnityEngine.UIElements;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour, IPointerEnterHandler
{
	[ReadOnly] public Movement Movement;

	private void Update()
	{
		if (Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0)
			Movement.AddLinearForce(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")));
		if (Input.GetAxis("Mouse X") != 0)
			Movement.AddAngularForce(new Vector3(0, Mathf.Clamp(Input.GetAxis("Mouse X"), -1, 1), 0));
		if (Input.GetKey(KeyCode.Space))
			Movement.AddLinearForce(Vector3.forward);
	}


	public void SayCoucou()
	{
		Debug.Log("Coucou");
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		Debug.Log("Interface coucou");
	}
}
