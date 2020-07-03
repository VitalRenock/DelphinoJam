﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkStateIA : StateMachineBehaviour
{
	IAEntity iAEntity;

	// OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		Debug.Log("Enter Walk State");
		animator.GetComponent<MeshRenderer>().material.color = Color.blue;
		iAEntity = animator.GetComponent<IAEntity>();
	}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		//Debug.Log("Update Walk State");
	}

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		Debug.Log("Exit Walk State");

		iAEntity.NavMeshAgent.ResetPath();
	}
}