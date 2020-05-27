using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Sirenix.OdinInspector;

[System.Serializable]
public class MoveInfos
{
	#region Translation

	private Vector3 translationVelocity = Vector3.zero;
	[ShowInInspector] public Vector3 CurrentTranslationVelocity => translationVelocity;

	public void AddTranslationForce(Vector3 force)
	{
		Debug.Log("AddTranslationForce");

		translationVelocity += force;

		CheckProximityToZero(translationVelocity, 0.01f);
	}
	public void AddTranslationForceClamped(MovementData movementData, Vector3 force)
	{
		Debug.Log("AddTranslationForceClamped");

		translationVelocity += force;
		translationVelocity.x = Mathf.Clamp(translationVelocity.x, -movementData.TranslationSpeed.MinSpeed.x, movementData.TranslationSpeed.MaxSpeed.x);
		translationVelocity.y = Mathf.Clamp(translationVelocity.y, -movementData.TranslationSpeed.MinSpeed.y, movementData.TranslationSpeed.MaxSpeed.y);
		translationVelocity.z = Mathf.Clamp(translationVelocity.z, -movementData.TranslationSpeed.MinSpeed.z, movementData.TranslationSpeed.MaxSpeed.z);

		CheckProximityToZero(translationVelocity, 0.01f);
	}
	public void ResetTranslationVelocity()
	{
		Debug.Log("ResetTranslationVelocity");

		translationVelocity = Vector3.zero;
	}

	#endregion

	#region Rotation

	private Vector3 rotationVelocity = Vector3.zero;
	[ShowInInspector] public Vector3 CurrentRotationVelocity => rotationVelocity;

	public void AddRotationForce(Vector3 force)
	{
		Debug.Log("AddRotationForce");

		rotationVelocity += force;

		CheckProximityToZero(rotationVelocity, 0.01f);
	}
	public void AddRotationForceClamped(MovementData movementData, Vector3 force)
	{
		Debug.Log("AddRotationForceClamped");

		rotationVelocity += force;
		rotationVelocity.x = Mathf.Clamp(rotationVelocity.x, -movementData.RotationSpeed.MinSpeed.x, movementData.RotationSpeed.MaxSpeed.x);
		rotationVelocity.y = Mathf.Clamp(rotationVelocity.y, -movementData.RotationSpeed.MinSpeed.y, movementData.RotationSpeed.MaxSpeed.y);
		rotationVelocity.z = Mathf.Clamp(rotationVelocity.z, -movementData.RotationSpeed.MinSpeed.z, movementData.RotationSpeed.MaxSpeed.z);

		CheckProximityToZero(rotationVelocity, 0.01f);
	}
	public void ResetRotationVelocity()
	{
		Debug.Log("ResetRotationVelocity");

		rotationVelocity = Vector3.zero;
	}

	#endregion

	void CheckProximityToZero(Vector3 vectorToCheck, float valueForZero)
	{
		Debug.Log("CheckProximityToZero");

		if (vectorToCheck.x > -valueForZero && vectorToCheck.x < valueForZero)
			vectorToCheck.x = 0f;
		else if (vectorToCheck.y > -valueForZero && vectorToCheck.y < valueForZero)
			vectorToCheck.y = 0f;
		else if (vectorToCheck.z > -valueForZero && vectorToCheck.z < valueForZero)
			vectorToCheck.z = 0f;
	}
}
