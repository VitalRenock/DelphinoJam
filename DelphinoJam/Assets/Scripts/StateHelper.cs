using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StateHelper : MonoBehaviour
{
	public bool Enable = true;
	[ReadOnly] public UnityEvent IsEnable = new UnityEvent();

	public List<StateAction> AllStates;


	private void Update()
	{
		foreach (StateAction action in AllStates)
			if (!action.enabled)
			{
				IsEnable.AddListener(action.Invoke);
				action.enabled = true;
			}
			else
			{
				IsEnable.RemoveListener(action.Invoke);
				action.enabled = false;
			}
		if (Enable)
			IsEnable?.Invoke();
	}
}