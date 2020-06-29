using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tool
{
	public string Name { get; }
	public float Range { get; }
	public float Damage { get; }
	public float ReloadTime { get; }

	public abstract void Use();
}
