using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;


public class StatsComponent : MonoBehaviour
{
	[TabGroup("Awake")] [DisableInPlayMode] public bool LoadAtAwake = false;
	[TabGroup("Awake")] [DisableInPlayMode] [ShowIf("LoadAtAwake")] [SerializeField] [AssetsOnly] StatsGroupData StatsGroupData = null;

	[DisableInPlayMode] [HideIf("LoadAtAwake")] public StatsGroup AllStats;


	private void Awake()
	{
		if (LoadAtAwake)
			LoadNewStats(StatsGroupData);
	}

	public void LoadNewStats(StatsGroupData statsData)
	{
		if (statsData == null)
		{
			Debug.LogError("LoadNewStats() => No reference for 'Stats Group Data' in 'StatsComponent'.");
			return;
		}
		else
			AllStats = statsData.StatsGroup;
	}
	public StatsInt GetStatsInt(string name)
	{
		StatsInt findedStats = null;
		foreach (StatsInt stats in AllStats.StatsInts)
			if (stats.Name == name)
				findedStats = stats;
		return findedStats;
	}
	public StatsFloat GetStatsFloat(string name)
	{
		StatsFloat findedStats = null;
		foreach (StatsFloat stats in AllStats.StatsFloats)
			if (stats.Name == name)
				findedStats = stats;
		return findedStats;
	}
}