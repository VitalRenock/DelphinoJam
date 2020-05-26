using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : Manager<PlayerManager, PlayerData>
{
	public override void Load(PlayerData dataToLoad)
	{
		base.Load(dataToLoad);

		Player player = GameObjectLoaded.AddComponent<Player>();
		player.MovementDataLoaded = dataToLoad.MovementData;

		GameObjectLoaded.transform.position = DataLoaded.StartPosition;
	}

	public override void Unload()
	{
		base.Unload();
	}
}
