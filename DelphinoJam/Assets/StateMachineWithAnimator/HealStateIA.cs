using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealStateIA : StateMachineBehaviour
{
	IAEntity iAEntity;

	float lastTimeHeal = 0f;

	// OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		Debug.Log("Enter Heal State");
		animator.GetComponent<MeshRenderer>().material.color = Color.green;
		iAEntity = animator.GetComponent<IAEntity>();

		lastTimeHeal = Time.time - iAEntity.HealReloadTime;
	}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		//Debug.Log("Update Heal State");

		Heal();
	}

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		Debug.Log("Exit Heal State");

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