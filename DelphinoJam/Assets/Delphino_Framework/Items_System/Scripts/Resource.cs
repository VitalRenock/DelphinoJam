using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(StatsComponent), typeof(ItemSpawner))]
public class Resource : MonoBehaviour
{
	public UnityEvent onItemSpawning;

	public void CheckStatsAtZero(StatsInt stats)
	{
		if (stats.CurrentValue == 0)
			onItemSpawning?.Invoke();
	}
}