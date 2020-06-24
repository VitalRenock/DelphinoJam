using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[CreateAssetMenu(fileName = "GameData_X", menuName = "Datas/New Game")]
public class GameData : ScriptableObject
{
	[TabGroup("Terrain")][AssetsOnly] 
	public TerrainData TerrainData;

	[TabGroup("Camera")][AssetsOnly]
	public CameraData CameraData;

	[TabGroup("Player")][AssetsOnly]
	public PlayerData PlayerData;
}