using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
	public GameData GameDataToLoad;

	private void Awake()
	{
		Load();
	}

	public void Load()
	{
		TerrainManager.I.Load(GameDataToLoad.TerrainData);
		PlayerManager.I.Load(GameDataToLoad.PlayerData);
		CameraManager.I.Load(GameDataToLoad.CameraData);
		LightManager.I.Load(GameDataToLoad.LightData);
		TimeManager.I.Load();
	}
	public void Unload()
	{
		TimeManager.I.Unload();
		LightManager.I.Unload();
		CameraManager.I.Unload();
		PlayerManager.I.Unload();
		TerrainManager.I.Unload();
	}
}