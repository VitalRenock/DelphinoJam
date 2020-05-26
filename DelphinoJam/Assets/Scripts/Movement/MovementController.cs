using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MovementController
{
	public static void Translate(Transform transform, Vector3 velocity)
	{
		transform.Translate(velocity * Time.deltaTime);
	}
}
