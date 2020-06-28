using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


[RequireComponent(typeof(NavMeshAgent), typeof(MoveIAProcessor))]
public class IAEntity : MonoBehaviour, IEntity
{
	NavMeshAgent navMeshAgent;
	MoveIAProcessor moveIAProcessor;

	private void Awake()
	{
		navMeshAgent = GetComponent<NavMeshAgent>();
		moveIAProcessor = GetComponent<MoveIAProcessor>();
	}

	public void MoveIaAction(Vector3 destination)
	{
		MoveIACommand newMoveIACommand = new MoveIACommand(navMeshAgent, destination);
		moveIAProcessor.ExecuteCommand(newMoveIACommand);
	}
}