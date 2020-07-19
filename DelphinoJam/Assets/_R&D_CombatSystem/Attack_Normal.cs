using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_Normal : Attack_Base
{
	public Attack_Normal(float damage, AttackType attackType, float cost, float reloadTime, float lastUseTime) : base(damage, attackType, cost, reloadTime, lastUseTime)
	{
	}
}
