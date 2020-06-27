using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputManager : Singleton<InputManager>
{
	public UnityEvent onSpaceKeyDown = new UnityEvent();
	public MouseClickTerrainEvent onMouseClickOnTerrain = new MouseClickTerrainEvent();

	public void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
			onSpaceKeyDown?.Invoke();

		if (Input.GetMouseButtonDown(0))
		{
			RaycastHit raycastHit;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

			if (Physics.Raycast(ray,out raycastHit))
				onMouseClickOnTerrain?.Invoke(raycastHit.point);
		}
	}


	public Vector3 ReadMoveInput()
	{
		Vector3 direction = Vector3.zero;
		direction.x = Input.GetAxis("Horizontal");
		direction.z = Input.GetAxis("Vertical");

		return direction;
	}
	public bool ReadJumpInput()
	{
		if (Input.GetKeyDown(KeyCode.Space))
			return true;
		else
			return false;
	}
	public bool ReadUndoInput()
	{
		if (Input.GetKey(KeyCode.KeypadEnter))
			return true;
		else
			return false;
	}

	public Vector3? GetClickPosition()
	{
		if (Input.GetMouseButtonDown(0))
		{
			RaycastHit raycastHit;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

			if (Physics.Raycast(ray, out raycastHit))
				return raycastHit.point;
		}
		return null;
	}
}

[System.Serializable]
public class MouseClickTerrainEvent : UnityEvent<Vector3> { }