using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Sirenix.OdinInspector;

[System.Serializable]
public class TimeCycle
{
	[TabGroup("Properties")]
	public Identity Identity;
	[TabGroup("Properties")]
	public float Duration;
	[TabGroup("Events")]
	public UnityEvent OnBeginCycle = new UnityEvent();
	[TabGroup("Events")]
	public UnityEvent OnEndingCycle = new UnityEvent();
}
public class OnSwitchCycleEvent : UnityEvent<TimeCycle> { };