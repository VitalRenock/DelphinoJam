using UnityEngine.Events;

public class CommandUnityActionExample : Command
{
	UnityAction unityAction;

	public CommandUnityActionExample(UnityAction unityAction) : base()
	{
		this.unityAction = unityAction;
	}

	public override void Execute()
	{
		unityAction.Invoke();
	}
	public override void Undo()
	{
		unityAction.Invoke();
	}
}