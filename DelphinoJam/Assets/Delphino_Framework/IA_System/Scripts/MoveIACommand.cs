using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveIACommand : Command
{
	NavMeshAgent navMeshAgent;
	Vector3 origin;
	Vector3 destination;


	public MoveIACommand(NavMeshAgent navMeshAgent, Vector3 destination) : base()
	{
		this.navMeshAgent = navMeshAgent;
		this.destination = destination;
	}


	public override void Execute()
	{
		origin = navMeshAgent.transform.position;
		navMeshAgent.SetDestination(destination);
	}

	public override void Undo()
	{
		navMeshAgent.isStopped = true;
		navMeshAgent.SetDestination(origin);
	}
}