using UnityEngine;


public class PlayerMoveCommand : Command
{
	// Options supplémentaires pour une MoveCommand.
	Transform transform;
	Vector3 direction;


	public PlayerMoveCommand(Transform transform, Vector3 direction) : base()
	{
		this.transform = transform;
		this.direction = direction;
	}


	// override de ce qu'on doit faire.
	public override void Execute()
	{
		transform.position += direction * 0.1f;
	}
	public override void Undo()
	{
		transform.position -= direction * 0.1f;
	}
}