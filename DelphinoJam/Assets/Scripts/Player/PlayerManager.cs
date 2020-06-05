

public class PlayerManager : Manager<PlayerManager, PlayerData>
{
	public override void Load(PlayerData dataToLoad)
	{
		base.Load(dataToLoad);

		Player player = GameObjectLoaded.AddComponent<Player>();

		// Temporary
		player.Movement = GameObjectLoaded.AddComponent<Movement>();
		player.Movement.MovementData = DataLoaded.MovementData;

		GameObjectLoaded.transform.position = DataLoaded.StartPosition;
	}

	public override void Unload()
	{
		base.Unload();
	}
}