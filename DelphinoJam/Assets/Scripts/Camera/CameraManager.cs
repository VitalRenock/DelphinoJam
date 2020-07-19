using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : Manager<CameraManager, CameraData>
{
	public override void Load(CameraData dataToLoad)
	{
		base.Load(dataToLoad);
	}

	public override void Unload()
	{
		base.Unload();
	}
}