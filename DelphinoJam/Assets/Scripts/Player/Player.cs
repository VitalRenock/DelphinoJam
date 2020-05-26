using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using System;

public class Player : MonoBehaviour
{
	[SerializeField] public MovementData MovementDataLoaded;
	public Vector3 CurrentVelocity = Vector3.zero;

	private void Update()
	{
		CurrentVelocity.z += Input.GetAxis("Vertical") * MovementDataLoaded.AccelerationPower;
		CurrentVelocity.z = Mathf.Clamp(CurrentVelocity.z, -MovementDataLoaded.MaxSpeed, MovementDataLoaded.MaxSpeed);
		CurrentVelocity.x += Input.GetAxis("Horizontal") * MovementDataLoaded.AccelerationPower;
		CurrentVelocity.x = Mathf.Clamp(CurrentVelocity.x, -MovementDataLoaded.MaxSpeed, MovementDataLoaded.MaxSpeed);

		MovementController.Translate(transform, CurrentVelocity);

		if(Input.GetKey(KeyCode.Space))
			Vector3.SmoothDamp(CurrentVelocity, Vector3.zero, ref CurrentVelocity, 32f);
	}
}
