using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : Manager<CameraManager, CameraData>
{
	public override void Load(CameraData dataToLoad)
	{
		base.Load(dataToLoad);

		GameObjectLoaded.transform.parent = PlayerManager.I.GameObjectLoaded.transform;
		GameObjectLoaded.transform.localPosition = DataLoaded.PositionRelativePlayer;
		GameObjectLoaded.transform.eulerAngles = DataLoaded.Rotation;
	}

	public override void Unload()
	{
		base.Unload();
	}
}