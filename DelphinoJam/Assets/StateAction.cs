using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StateAction : MonoBehaviour
{
	[ReadOnly] public bool Enable = true;
	public UnityEvent Actions;
	public void Invoke() => Actions.Invoke();

	public void Coucou() => Debug.Log("Coucou");
}
