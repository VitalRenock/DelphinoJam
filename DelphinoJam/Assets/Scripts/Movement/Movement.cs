using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class Movement : MonoBehaviour
{
	// Velocity = Speed * Direction.normalized

	[ReadOnly] public MovementData MovementData;

	public bool CanMove = true;
	public bool CanTranslate = true;
	public bool CanRotate = true;

	Vector3 linearVelocity = Vector3.zero;
	[ShowInInspector] public Vector3 LinearVelocity => linearVelocity;

	Vector3 angularVelocity = Vector3.zero;
	[ShowInInspector] public Vector3 AngularVelocity => angularVelocity;


	private void Update()
	{
		ApplyVelocities();
		ResetVelocities();
	}

	public void AddLinearForce(Vector3 force)
	{
		linearVelocity += force;
	}
	public void AddAngularForce(Vector3 force)
	{
		angularVelocity += force;
	}

	void ApplyVelocities()
	{
		if (!CanMove)
			return;
		if (CanTranslate)
			transform.Translate(linearVelocity * MovementData.LinearSpeed * Time.deltaTime);
		if (CanRotate)
			transform.Rotate(angularVelocity * MovementData.AngularSpeed * Time.deltaTime);
	}
	void ResetVelocities()
	{
		linearVelocity = Vector3.zero;
		angularVelocity = Vector3.zero;
	}
}