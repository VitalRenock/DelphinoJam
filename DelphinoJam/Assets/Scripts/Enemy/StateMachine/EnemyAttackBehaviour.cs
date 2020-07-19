using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackBehaviour : StateMachineBehaviour
{
	Enemy enemy;
	float lastAttackTime = 0f;

	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		animator.GetComponent<MeshRenderer>().material.color = Color.red;
		enemy = animator.GetComponent<Enemy>();

		enemy.NavMeshAgent.SetDestination(enemy.Player.position);
	}
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		enemy.NavMeshAgent.SetDestination(enemy.Player.position);

		Attack();
	}
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		enemy.NavMeshAgent.ResetPath();
	}

	void Attack()
	{
		if (Time.time >= lastAttackTime + enemy.AttackReloadTime && enemy.DistancePlayer <= enemy.AttackDistance)
		{
			enemy.Player.GetComponent<StatsComponent>().GetStatsInt("Life").RemoveValue(enemy.AttackValue);
			lastAttackTime = Time.time;
		}
	}
}