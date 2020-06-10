using UnityEngine;

public class PlayerManager : Manager<PlayerManager, PlayerData>
{
	public ItemData TestItem;
	public Vector3 TestPosition;

	public override void Load(PlayerData dataToLoad)
	{
		base.Load(dataToLoad);

		//Player player = GameObjectLoaded.AddComponent<Player>();

		GameObjectLoaded.transform.position = DataLoaded.StartPosition;
	}

	public override void Unload()
	{
		base.Unload();
	}

	public void TestChangeJumpCount()
	{
		GameObjectLoaded.GetComponent<Player>().RigidController.MaxJump++;
	}
}