﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
	public GameData GameDataToLoad;

	public PlayerEntity PlayerTestStatePattern;

	void Load() { }
	void Unload() { }
}