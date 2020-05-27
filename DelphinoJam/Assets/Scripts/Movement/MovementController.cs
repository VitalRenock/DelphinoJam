using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MovementController
{
	public static void Translate(Transform transform, MoveInfos moveInfos)
	{
		transform.Translate(moveInfos.CurrentTranslationVelocity * Time.deltaTime);
	}

	public static void Rotate(Transform transform, MoveInfos moveInfos)
	{
		transform.Rotate(moveInfos.CurrentRotationVelocity * Time.deltaTime);
	}
}
