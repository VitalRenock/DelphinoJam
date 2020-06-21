using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputManager : Singleton<InputManager>
{
	public UnityEvent onTabKeyDown;

	public void Update()
	{
		if (Input.GetKeyDown(KeyCode.Tab))
			onTabKeyDown?.Invoke();
	}
}
