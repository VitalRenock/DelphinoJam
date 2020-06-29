using UnityEngine;

public abstract class CommandTransform : Command
{
	protected Transform Transform;

	// Inheritance Constructor
	protected CommandTransform(Transform transform)
	{
		Transform = transform;
	}
}