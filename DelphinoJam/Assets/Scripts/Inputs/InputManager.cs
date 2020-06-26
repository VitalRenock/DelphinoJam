using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputManager : Singleton<InputManager>
{
	public UnityEvent onTabKeyDown = new UnityEvent();
	public UnityEvent onMinusKeyDown = new UnityEvent();
	public UnityEvent onPlusKeyDown = new UnityEvent();

	// Temporary
	Player player;


	private void Awake()
	{
		// Temporary
		player = FindObjectOfType<Player>();
	}
	private void Start()
	{
		// Temporary
		onMinusKeyDown.AddListener(() => { player.StatsComponent.GetStatsInt("Life").RemoveValue(5); });
		onPlusKeyDown.AddListener(() => { player.StatsComponent.GetStatsInt("Armor").AddValue(5); });
	}


	public void Update()
	{
		if (Input.GetKeyDown(KeyCode.Tab))
			onTabKeyDown?.Invoke();
		if (Input.GetKeyDown(KeyCode.KeypadMinus))
			onMinusKeyDown?.Invoke();
		if (Input.GetKeyDown(KeyCode.KeypadPlus))
			onPlusKeyDown?.Invoke();
	}
}