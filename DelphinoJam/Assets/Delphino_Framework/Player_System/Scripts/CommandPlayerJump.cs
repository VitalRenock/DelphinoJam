using UnityEngine.Events;

public class CommandPlayerJump : Command
{
	UnityAction jumpAction;

	public CommandPlayerJump(UnityAction jumpAction) : base()
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