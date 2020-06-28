using UnityEngine.Events;

public class PlayerJumpCommand : Command
{
	UnityAction jumpAction;

	public PlayerJumpCommand(UnityAction jumpAction) : base()
	{
		this.jumpAction = jumpAction;
	}

	public override void Execute()
	{
		jumpAction.Invoke();
	}
	public override void Undo()
	{
		jumpAction.Invoke();
	}
}