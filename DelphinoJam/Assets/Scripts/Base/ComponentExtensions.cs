using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ComponentExtensions
{
	#region Vectors Extensions

	public static Vector2 Round(this Vector2 vector)
	{
		return new Vector2(Mathf.Round(vector.x), Mathf.Round(vector.y));
	}
	public static Vector3 Round(this Vector3 vector)
	{
		return new Vector3(Mathf.Round(vector.x), Mathf.Round(vector.y), Mathf.Round(vector.z));
	}

	#endregion


	#region List<T> Extensions

	public static void Swap<T>(this List<T> list, int indexA, int indexB)
	{
		if (indexA > list.Count || indexB > list.Count)
			Debug.LogWarning("Switch items impossible, an item(s) is out of range of the list");
		else
		{
			T tmp = list[indexA];
			list[indexA] = list[indexB];
			list[indexB] = tmp;
		}
	}

	#endregion

	#region GameObject Extensions

	public static T GetOrAddComponent<T>(this GameObject gameObject) where T : Component
	{
		T component;

		if (!gameObject.TryGetComponent(out component))
			component = gameObject.AddComponent<T>();

		return component;
	}

	#endregion
}
