using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMoveProcessor))]
public class PlayerEntity : MonoBehaviour, IEntity
{
	PlayerMoveProcessor playerMoveProcessor;

	private void Awake() => playerMoveProcessor = GetComponent<PlayerMoveProcessor>();
	private void Update()
	{
		// Appel des commandes
		Vector3 direction = InputManager.I.ReadMoveInput();
		if (InputManager.I.ReadJumpInput())
		{
			PlayerJumpCommand jumpCommand = new PlayerJumpCommand(this, GetComponent<RigidbodyController>());
			playerMoveProcessor.ExecuteCommand(jumpCommand);
		}
		else if (direction != Vector3.zero)
		{
			PlayerMoveCommand moveCommand = new PlayerMoveCommand(transform, direction);
			playerMoveProcessor.ExecuteCommand(moveCommand);
		}
		else if (InputManager.I.ReadUndoInput())
		{
			playerMoveProcessor.UndoCommand();
		}
	}
}