using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealBehaviour : StateMachineBehaviour
{
	Enemy iAEntity;
	float lastTimeHeal = 0f;

	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		animator.GetComponent<MeshRenderer>().material.color = Color.green;
		iAEntity = animator.GetComponent<Enemy>();

		lastTimeHeal = Time.time - iAEntity.HealReloadTime;
	}
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		Heal();
	}
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		iAEntity.NavMeshAgent.ResetPath();
	}

	void Heal()
	{
		if (Time.time >= lastTimeHeal + iAEntity.HealReloadTime)
		{
			iAEntity.Life.AddValue(iAEntity.HealValue);
			lastTimeHeal = Time.time;
		}
	}
}