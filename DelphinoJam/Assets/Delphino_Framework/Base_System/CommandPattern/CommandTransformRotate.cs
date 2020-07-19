using UnityEngine;
using UnityEngine.Animations;

public class CommandTransformRotate : CommandTransform
{
	Axis axis;
	float angle;
	Space space;

	public CommandTransformRotate(Transform transform, Axis axis, float angle, Space space = Space.Self) : base(transform)
	{
		this.axis = axis;
		this.angle = angle;
		this.space = space;
	}

	public override void Execute()
	{
		switch (axis)
		{
			case Axis.None:
				break;
			case Axis.X:
				Transform.Rotate(Vector3.right * angle, space);
				break;
			case Axis.Y:
				Transform.Rotate(Vector3.up * angle, space);
				break;
			case Axis.Z:
				Transform.Rotate(Vector3.forward * angle, space);
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
				Transform.Rotate(Vector3.right * -angle, space);
				break;
			case Axis.Y:
				Transform.Rotate(Vector3.up * -angle, space);
				break;
			case Axis.Z:
				Transform.Rotate(Vector3.forward * -angle, space);
				break;
			default:
				break;
		}
	}
}