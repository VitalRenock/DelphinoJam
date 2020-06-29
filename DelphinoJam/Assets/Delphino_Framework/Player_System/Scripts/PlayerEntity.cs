using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

[RequireComponent(typeof(TransformProcessor), typeof(StatsComponent))]
public class PlayerEntity : MonoBehaviour, IEntity
{
	// Temporary MoveSpeed
	public float MoveSpeed;
	public float StrafeSpeed;
	public float RotateSpeed;
	public float CamRotateSpeed;

	TransformProcessor transformProcessor;

	StatsIntProcessor statsIntProcessor;
	StatsComponent statsComponent;
	// Temporary Stamina shortcut
	StatsInt Stamina;

	Camera cameraPlayer;

	private void Awake()
	{
		transformProcessor = GetComponent<TransformProcessor>();
		statsComponent = GetComponent<StatsComponent>();
		statsIntProcessor = GetComponent<StatsIntProcessor>();

		// Temporary Stamina
		Stamina = statsComponent.GetStatsInt("Stamina");

		cameraPlayer = GetComponentInChildren<Camera>();
	}


	public void MoveCommandCalls(float input)
	{
		// Stamina...
		float finalSpeed = input * MoveSpeed * Time.deltaTime;
		CommandTransformTranslate command = new CommandTransformTranslate(transform, Axis.Z, finalSpeed, Space.Self);
		transformProcessor.ExecuteCommand(command);
	}
	public void StrafeCommandCalls(float input)
	{
		// Stamina...
		float finalSpeed = input * StrafeSpeed * Time.deltaTime;
		CommandTransformTranslate command = new CommandTransformTranslate(transform, Axis.X, finalSpeed, Space.Self);
		transformProcessor.ExecuteCommand(command);
	}
	public void RotateCommandCalls(float input)
	{
		// Stamina...
		float finalSpeed = input * RotateSpeed * Time.deltaTime;
		CommandTransformRotate command = new CommandTransformRotate(transform, Axis.Y, finalSpeed, Space.Self);
		transformProcessor.ExecuteCommand(command);
	}
	public void RotateCameraCommandCalls(float input)
	{
		float finalSpeed = -input * CamRotateSpeed * Time.deltaTime;
		CommandTransformRotate command = new CommandTransformRotate(cameraPlayer.transform, Axis.X, finalSpeed, Space.Self);
		transformProcessor.ExecuteCommand(command);
	}
	public void UndoTransformProcessor() => transformProcessor.UndoCommand();


	public void CameraHitCalls(RaycastHit raycastHit)
	{
		if (raycastHit.transform.gameObject.layer == LayerMask.NameToLayer("Terrain"))
		{
			Debug.Log(raycastHit.transform.name);
		}
		else if (raycastHit.transform.gameObject.layer == LayerMask.NameToLayer("Resource"))
		{
			Debug.Log(raycastHit.transform.name);
			StatsComponent statsComponent = raycastHit.transform.gameObject.GetComponent<StatsComponent>();
			statsComponent.GetStatsInt("Life").RemoveValue(10);
		}
	}

	#region Temporary Jump

	// Temporary Jump
	Coroutine coroutineIsJumping;
	public void Jump()
	{
		if (coroutineIsJumping == null)
			coroutineIsJumping = StartCoroutine(IsJumping(statsComponent.GetStatsFloat("JumpHeight").CurrentValue));
	}
	IEnumerator IsJumping(float jumpHeight)
	{
		float startY = transform.position.y;

		while (transform.position.y < startY + jumpHeight)
		{
			transform.Translate(Vector3.up * statsComponent.GetStatsFloat("JumpSpeed").CurrentValue * Time.deltaTime, Space.Self);
			yield return null;
		}

		yield return new WaitForSeconds(0.1f);

		while (transform.position.y > startY)
		{
			transform.Translate(Vector3.down * statsComponent.GetStatsFloat("FallSpeed").CurrentValue * Time.deltaTime, Space.Self);
			yield return null;
		}
		transform.position = new Vector3(transform.position.x, startY, transform.position.z);
		coroutineIsJumping = null;
	}

	#endregion
}