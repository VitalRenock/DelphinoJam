using UnityEngine;
using UnityEngine.Animations;

public class CommandTransformTranslate : CommandTransform
{
	Axis axis;
	float speed;
	Space space;

	public CommandTransformTranslate(Transform transform, Axis axis, float speed, Space space = Space.Self) : base(transform)
	{
		this.axis = axis;
		this.speed = speed;
		this.space = space;
	}

	public override void Execute()
	{
		switch (axis)
		{
			case Axis.None:
				break;
			case Axis.X:
				Transform.Translate(Vector3.right * speed, space);
				break;
			case Axis.Y:
				Transform.Translate(Vector3.up * speed, space);
				break;
			case Axis.Z:
				Transform.Translate(Vector3.forward * speed, space);
				break;
			default:
				break;
		}
	}
	public override void Undo()
	{
		switch (axis)
		{
			case Axis.None:
				break;
			case Axis.X:
				Transform.Translate(Vector3.right * -speed, space);
				break;
			case Axis.Y:
				Transform.Translate(Vector3.up * -speed, space);
				break;
			case Axis.Z:
				Transform.Translate(Vector3.forward * -speed, space);
				break;
			default:
				break;
		}
	}
}