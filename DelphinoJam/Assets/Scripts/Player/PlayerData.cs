using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData_X", menuName = "Datas/New Player")]
public class PlayerData : Data
{
	public Vector3 StartPosition;
	public MovementData MovementData;
}
