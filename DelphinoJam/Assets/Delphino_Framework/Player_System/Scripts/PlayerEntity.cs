using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMoveProcessor), typeof(StatsComponent))]
public class PlayerEntity : MonoBehaviour, IEntity
{
	PlayerMoveProcessor playerMoveProcessor;
	StatsComponent statsComponent;

	// Temporary Stamina
	StatsInt Stamina;

	private void Awake() 
	{
		playerMoveProcessor = GetComponent<PlayerMoveProcessor>();
		statsComponent = GetComponent<StatsComponent>();

		// Temporary Stamina
		Stamina = statsComponent.GetStatsInt("Stamina");
	}
	private void Update() => CommandCalls();

	void CommandCalls()
	{
		Vector3 direction = InputsManager.I.ReadMoveInput();

		// Temporary Stamina
		if (InputsManager.I.ReadJumpInput() && Stamina.CurrentValue > 0)
		{
			if (Stamina.CurrentValue > 5)
			{
				PlayerJumpCommand jumpCommand = new PlayerJumpCommand(Jump);
				playerMoveProcessor.ExecuteCommand(jumpCommand);
			}

			Stamina.RemoveValue(Mathf.RoundToInt(12000f * Time.deltaTime));
		}
		else if (direction != Vector3.zero && Stamina.CurrentValue > 0)
		{
			if (Stamina.CurrentValue > 5)
			{
				PlayerMoveCommand moveCommand = new PlayerMoveCommand(transform, direction);
				playerMoveProcessor.ExecuteCommand(moveCommand);
			}

			Stamina.RemoveValue(Mathf.RoundToInt(120f * Time.deltaTime));
		}
		else if (InputsManager.I.ReadUndoInput())
		{
			playerMoveProcessor.UndoCommand();
		}
		else
		{
			Stamina.AddValue(Mathf.RoundToInt(180f * Time.deltaTime));
		}
	}

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
}