using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[CreateAssetMenu(fileName = "MovementData_X", menuName = "Datas/New Movement")]
public class MovementData : ScriptableObject
{
	public SpeedInfos TranslationSpeed;
	public SpeedInfos RotationSpeed;
}
