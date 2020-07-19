using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Attack_Base
{
	public float Damage { get; set; }
	public AttackType AttackType { get; set; }
	public float Cost { get; set; }
	public float ReloadTime { get; set; }
	public float LastUseTime { get; set; }


	protected Attack_Base(float damage, AttackType attackType, float cost, float reloadTime, float lastUseTime)
	{
		Damage = damage;
		AttackType = attackType;
		Cost = cost;
		ReloadTime = reloadTime;
		LastUseTime = lastUseTime;
	}

}

public enum AttackType
{
	Normal,
	Special
}