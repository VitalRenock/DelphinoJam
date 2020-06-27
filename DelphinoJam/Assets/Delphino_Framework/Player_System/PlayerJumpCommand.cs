public class PlayerJumpCommand : Command
{
	RigidbodyController rigidbodyController;


	public PlayerJumpCommand(IEntity iEntity, RigidbodyController rigidbodyController) : base()
	{
		this.rigidbodyController = rigidbodyController;
	}


	public override void Execute()
	{
		rigidbodyController.Jump();
	}
	public override void Undo()
	{
		rigidbodyController.Jump();
	}
}