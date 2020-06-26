using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Sirenix.OdinInspector;


[RequireComponent(typeof(Image))]
public class StatsBarUI : MonoBehaviour
{
	[TabGroup("Options")]
	public Image.FillMethod FillMethod;

	[TabGroup("Awake")] [DisableInPlayMode] 
	public bool LoadAtAwake = false;

	[TabGroup("Awake")] [DisableInPlayMode] [ShowIf("LoadAtAwake")] 
	public StatsComponent StatsComponent;

	[TabGroup("Awake")] [DisableInPlayMode] [ShowIf("LoadAtAwake")] 
	public string StatsNameToLoad;

	[TabGroup("Awake")] [DisableInPlayMode] [ShowIf("LoadAtAwake")] [Tooltip("'UpdateBar()' listen specified 'StatsInt' event?")] 
	public bool AutoUpdate;

	[TabGroup("Events")] [DisableInPlayMode] 
	public UnityEvent onBarUpdated;

	Image image;


	void Awake()
	{
		image = gameObject.GetOrAddComponent<Image>();
		image.type = Image.Type.Filled;
		image.fillMethod = FillMethod;
	}
	private void Start()
	{
		if (LoadAtAwake)
			LoadStats();
	}


	public void UpdateBar(StatsInt statsInt)
	{
		image.fillAmount = (float)statsInt.CurrentValue / (float)statsInt.MaxValue;
		onBarUpdated?.Invoke();
	}


	void LoadStats()
	{
		if (StatsComponent == null || StatsNameToLoad == null)
			return;

		bool statsFounded = false;
		foreach (StatsInt statsInt in StatsComponent.AllStats.StatsInts)
			if (statsInt.Name == StatsNameToLoad)
			{
				statsFounded = true;
				image.fillAmount = (float)statsInt.CurrentValue / (float)statsInt.MaxValue;

				if (AutoUpdate)
					statsInt.onStatChanged.AddListener(UpdateBar);
			}
		if (!statsFounded)
			Debug.LogWarning("LoadStats() => StatsInt:" + StatsNameToLoad + " not found in " + StatsComponent.name);
	}
}