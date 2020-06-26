using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class StatsGroup
{
	[TabGroup("Ints Stats")] public StatsInt[] StatsInts;
	[TabGroup("Floats Stats")] public StatsFloat[] StatsFloats;
}