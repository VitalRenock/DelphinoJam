using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWalkBehaviour : StateMachineBehaviour
{
	Enemy iAEntity;

	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		animator.GetComponent<MeshRenderer>().material.color = Color.blue;
		iAEntity = animator.GetComponent<Enemy>();
	}
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{

	}
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		iAEntity.NavMeshAgent.ResetPath();
	}
}