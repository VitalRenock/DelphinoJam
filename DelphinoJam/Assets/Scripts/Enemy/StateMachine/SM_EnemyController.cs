using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class SM_EnemyController : SM_BaseAnimatorController
{
	Enemy iAEntity;

	protected override void Awake()
	{
		base.Awake();
		iAEntity = GetComponent<Enemy>();
	}
	protected override void Update()
	{
		base.Update();
	}

	protected override void CheckTransitions()
	{
		iAEntity.DistancePlayer = Vector3.Distance(transform.position, iAEntity.Player.position);

		if (Input.GetKeyDown(KeyCode.KeypadMinus))
			iAEntity.Life.RemoveValue(10);
		else if (Input.GetKeyDown(KeyCode.KeypadPlus))
			iAEntity.Life.AddValue(10);
	}
	protected override void UpdateTransitions()
	{
		if (!Animator.GetBool("PlayerIsNear") && iAEntity.DistancePlayer <= iAEntity.AgroDistance)
			Animator.SetBool("PlayerIsNear", true);
		else if (Animator.GetBool("PlayerIsNear") && iAEntity.DistancePlayer > iAEntity.AgroDistance)
			Animator.SetBool("PlayerIsNear", false);

		if (!Animator.GetBool("IsLowLife") && iAEntity.Life.CurrentValue <= 20)
			Animator.SetBool("IsLowLife", true);
		else if (Animator.GetBool("IsLowLife") && iAEntity.Life.CurrentValue > 20)
			Animator.SetBool("IsLowLife", false);
	}
}