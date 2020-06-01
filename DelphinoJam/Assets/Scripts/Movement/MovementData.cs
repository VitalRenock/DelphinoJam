using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MovementData_X", menuName = "Datas/New Movement")]
public class MovementData : ScriptableObject
{
	public float LinearSpeed = 0;
	public float AngularSpeed = 0;
}
