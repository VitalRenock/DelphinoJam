using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
	public GameData GameDataToLoad;

	// Temporary
	public List<MessageData> MessagesToPost;

	private void Start()
	{
		// Temporary
		for (int i = 0; i < MessagesToPost.Count; i++)
			MessageManager.I.Post(MessagesToPost[i], 5f, i *3f);
	}

	void Load() { }
	void Unload() { }
}