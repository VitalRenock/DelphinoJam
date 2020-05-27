using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using System;

public class Player : MonoBehaviour
{
	public MovementData MovementDataLoaded;
	[SerializeField] public MoveInfos MoveInfos = new MoveInfos();

	private void Update()
	{
		if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
			MoveInfos.AddTranslationForceClamped(MovementDataLoaded, CalculateTranslationForce());
		else if (MoveInfos.CurrentTranslationVelocity != Vector3.zero)
			MoveInfos.AddTranslationForce(-MoveInfos.CurrentTranslationVelocity * MovementDataLoaded.TranslationSpeed.BrakingForce);

		if (Input.GetAxisRaw("Mouse X") != 0)
			MoveInfos.AddRotationForceClamped(MovementDataLoaded, CalculateRotationForce());
		else if (MoveInfos.CurrentRotationVelocity != Vector3.zero)
			MoveInfos.AddRotationForce(-MoveInfos.CurrentRotationVelocity * MovementDataLoaded.RotationSpeed.BrakingForce);

		MovementController.Translate(transform, MoveInfos);
		MovementController.Rotate(transform, MoveInfos);
	}

	Vector3 CalculateTranslationForce()
	{
		float xForce = Input.GetAxis("Horizontal") * MovementDataLoaded.TranslationSpeed.AccelerationForce.x;
		float zForce = Input.GetAxis("Vertical") * MovementDataLoaded.TranslationSpeed.AccelerationForce.z;
		return new Vector3(xForce, 0, zForce);
	}
	Vector3 CalculateRotationForce()
	{
		float yForce = Input.GetAxis("Mouse X") * MovementDataLoaded.RotationSpeed.AccelerationForce.y;
		//float yForce = Mathf.Clamp(Input.GetAxis("Mouse X"), -1, 1) * MovementDataLoaded.RotationSpeed.AccelerationForce.y;
		return new Vector3(0, yForce, 0);
	}
}
