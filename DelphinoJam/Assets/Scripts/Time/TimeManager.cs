using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Sirenix.OdinInspector;

public class TimeManager : Singleton<TimeManager>
{
	[TabGroup("Cycles")][ReadOnly]
	public float CurrentTime;
	[TabGroup("Cycles")]
	public bool RunCycle = false;
	[TabGroup("Cycles")]
	public List<TimeCycle> TimeCycles;
	[TabGroup("Cycles")]
	public OnSwitchCycleEvent OnSwitchCycle = new OnSwitchCycleEvent();

	[TabGroup("Ticks")]
	public float MasterTickRate;
	[TabGroup("Ticks")]
	public UnityEvent onMasterTick = new UnityEvent();

	float _LastTick = 0;
	private void Start()
	{
		_LastTick = Time.time;

		StartCoroutine(LoopCycle());
	}
	private void Update()
	{
		if (Time.time >= _LastTick + MasterTickRate)
		{
			onMasterTick.Invoke();
			_LastTick = Time.time;
		}
	}

	public void Load()
	{

	}
	public void Unload()
	{
		StopAllCoroutines();
	}

	IEnumerator LoopCycle()
	{
		Debugger.I.DebugMessage("Start > LoopCycle");

		if (TimeCycles.Count <= 0)
		{
			Debugger.I.DebugError("No cycle in Cycles List!");
			yield break;
		}

		RunCycle = true;

		while (RunCycle)
		{
			for (int i = 0; i < TimeCycles.Count; i++)
			{
				yield return StartCoroutine(StartCycle(TimeCycles[i]));

				if (i == TimeCycles.Count)
					i = 0;
			}

			yield return null;
		}
	}

	IEnumerator StartCycle(TimeCycle timeCycle)
	{
		Debugger.I.DebugMessage("Start > StartCycle");

		OnSwitchCycle.Invoke(timeCycle);

		CurrentTime = 0;
		timeCycle.OnBeginCycle.Invoke();

		while (CurrentTime < timeCycle.Duration)
		{
			CurrentTime += Time.deltaTime;
			yield return null;
		}

		timeCycle.OnEndingCycle.Invoke();
	}
}