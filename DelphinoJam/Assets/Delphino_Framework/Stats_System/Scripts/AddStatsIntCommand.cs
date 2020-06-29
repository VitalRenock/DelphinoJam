using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddStatsIntCommand : Command
{
	StatsInt statsInt;
	int value;

	public AddStatsIntCommand(StatsInt statsInt, int value) : base()
	{
		this.statsInt = statsInt;
		this.value = value;
	}

	public override void Execute()
	{
		statsInt.AddValue(value);
	}

	public override void Undo()
	{
		statsInt.RemoveValue(value);
	}
}