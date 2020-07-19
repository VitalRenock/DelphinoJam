using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
	public GameData GameDataToLoad;
	public bool HideLockCursor = true;


	//public PlayerEntity PlayerTestStatePattern;

	private void Start()
	{
		if (HideLockCursor)
		{
			Cursor.visible = false;
			Cursor.lockState = CursorLockMode.Locked;
		}
	}

	void Load() { }
	void Unload() { }
}