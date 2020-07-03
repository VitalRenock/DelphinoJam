using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackStateIA : StateMachineBehaviour
{
	IAEntity iAEntity;
	float lastAttackTime = 0f;

	// OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		Debug.Log("Enter Attack State");
		animator.GetComponent<MeshRenderer>().material.color = Color.red;
		iAEntity = animator.GetComponent<IAEntity>();

		iAEntity.NavMeshAgent.SetDestination(iAEntity.Player.position);
	}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		//Debug.Log("Update Attack State");

		iAEntity.NavMeshAgent.SetDestination(iAEntity.Player.position);

		Attack();
	}

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		Debug.Log("Exit Attack State");

		iAEntity.NavMeshAgent.ResetPath();
	}

	void Attack()
	{
		if (Time.time >= lastAttackTime + iAEntity.AttackReloadTime && iAEntity.DistancePlayer <= iAEntity.AttackDistance)
		{
			iAEntity.Player.GetComponent<StatsComponent>().GetStatsInt("Life").RemoveValue(iAEntity.AttackValue);
			lastAttackTime = Time.time;
		}
	}
}