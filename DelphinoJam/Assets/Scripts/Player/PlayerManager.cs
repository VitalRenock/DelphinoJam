using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerManager : Manager<PlayerManager, PlayerData>
{
	public override void Load(PlayerData dataToLoad)
	{
		base.Load(dataToLoad);

		//Player player = GameObjectLoaded.AddComponent<Player>();
		Player player = GameObjectLoaded.GetComponent<Player>();
		Movement movement = GameObjectLoaded.AddComponent<Movement>();
		
		player.Movement = movement;
		movement.MovementData = DataLoaded.MovementData;

		GameObjectLoaded.transform.position = DataLoaded.StartPosition;
	}

	public override void Unload()
	{
		base.Unload();
	}
}
