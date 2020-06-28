using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Sirenix.OdinInspector;

public class InputsManager : Singleton<InputsManager>
{
	[DisableInPlayMode] [TabGroup("Mouse & Keyboard Events")]
	public List<InputKeyEvent> AllKeyEvents;

	[DisableInPlayMode] [TabGroup("Customs Events")]
	public MouseClickTerrainEvent onMouseClickOnTerrain = new MouseClickTerrainEvent();

	void Update() => CheckInputs();

	void CheckInputs()
	{
		foreach (InputKeyEvent inputKeyEvent in AllKeyEvents)
			if (Input.GetKeyDown(inputKeyEvent.KeyCode))
				inputKeyEvent.KeyEvent?.Invoke();
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

	public void SendClickPosition()
	{
		Vector3? destination = GetClickPosition();

		if (destination != null)
			onMouseClickOnTerrain?.Invoke((Vector3)destination);
	}
	public Vector3? GetClickPosition()
	{
		RaycastHit raycastHit;
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

		if (Physics.Raycast(ray, out raycastHit))
			return raycastHit.point;
		else
			return null;
	}
}

[System.Serializable]
public class InputKeyEvent
{
	[FoldoutGroup("Key Event")]
	public string Name;
	[FoldoutGroup("Key Event")]
	public KeyCode KeyCode;
	[FoldoutGroup("Key Event")]
	public UnityEvent KeyEvent = new UnityEvent();
}

[System.Serializable]
public class MouseClickTerrainEvent : UnityEvent<Vector3> { }