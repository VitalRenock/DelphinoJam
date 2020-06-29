using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveStatsIntCommand : Command
{
    StatsInt statsInt;
    int value;

    public RemoveStatsIntCommand(StatsInt statsInt, int value) : base()
    {
        this.statsInt = statsInt;
        this.value = value;
    }

    public override void Execute()
    {
        statsInt.RemoveValue(value);
    }

    public override void Undo()
    {
        statsInt.AddValue(value);
    }
}