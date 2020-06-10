using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[RequireComponent(typeof(Rigidbody))]
public class RigidbodyController : MonoBehaviour
{
	public float MoveSpeed = 1;
	public float TurnSpeed = 1;
	public float JumpSpeed = 1;
	public int MaxJump = 1;
	[ReadOnly] public int jumpCount = 0;
	
	[FoldoutGroup("Dependencies")]
	[ReadOnly] public Rigidbody Rigidbody;

	private void Awake() => Rigidbody = gameObject.GetOrAddComponent<Rigidbody>();

	public void Move() => Rigidbody.AddRelativeForce(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * MoveSpeed, ForceMode.Force);
	public void Turn() => Rigidbody.AddRelativeTorque(new Vector3(0, Mathf.Clamp(Input.GetAxis("Mouse X"), -1, 1), 0) * TurnSpeed, ForceMode.VelocityChange);
	public void Jump()
	{
		jumpCount++;
		Rigidbody.AddRelativeForce(Vector3.up * JumpSpeed, ForceMode.Impulse);
	}
}
