using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : Manager<LightManager, LightData>
{
	public override void Load(LightData dataToLoad)
	{
		base.Load(dataToLoad);
	}

	public override void Unload()
	{
		base.Unload();
	}
}
