using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CameraData_X", menuName = "Datas/New Camera")]
public class CameraData : Data
{
	public Vector3 PositionRelativePlayer;
	public Vector3 Rotation;
}