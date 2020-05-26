using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class TerrainManager : Manager<TerrainManager, TerrainData>
{
	public override void Load(TerrainData dataToLoad)
	{
		base.Load(dataToLoad);
	}

	public override void Unload()
	{
		base.Unload();
	}
}
