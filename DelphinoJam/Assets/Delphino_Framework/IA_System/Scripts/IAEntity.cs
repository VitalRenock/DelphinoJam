using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Sirenix.OdinInspector;

[RequireComponent(typeof(NavMeshAgent), typeof(Animator))]
public class IAEntity : MonoBehaviour
{
	[ReadOnly]
	public NavMeshAgent NavMeshAgent;

	[ShowInInspector] [ReadOnly]
	Animator animator;

	[ReadOnly]
	public Transform Player;


	[ReadOnly]
	public StatsComponent StatsComponent;

	[ReadOnly]
	public StatsInt Life;

	public float AgroDistance = 10f;

	public int AttackValue = 5;
	public float AttackReloadTime = 5f;
	public float AttackDistance = 3f;

	public int HealValue = 5;
	public float HealReloadTime = 5f;

	[ShowInInspector] [ReadOnly]
	public float DistancePlayer;

	private void Awake()
	{
		NavMeshAgent = GetComponent<NavMeshAgent>();
		animator = GetComponent<Animator>();
		Player = FindObjectOfType<PlayerEntity>().transform;
		StatsComponent = GetComponent<StatsComponent>();
		Life = StatsComponent.GetStatsInt("Life");
	}

	private void Update()
	{
		DistancePlayer = Vector3.Distance(transform.position, Player.position);

		if (Input.GetKeyDown(KeyCode.KeypadMinus))
			Life.RemoveValue(10);
		else if (Input.GetKeyDown(KeyCode.KeypadPlus))
			Life.AddValue(10);


		if (!animator.GetBool("PlayerIsNear") && DistancePlayer <= AgroDistance)
			animator.SetBool("PlayerIsNear", true);
		else if (animator.GetBool("PlayerIsNear") && DistancePlayer > AgroDistance)
			animator.SetBool("PlayerIsNear", false);

		if (!animator.GetBool("IsLowLife") && Life.CurrentValue <= 20)
			animator.SetBool("IsLowLife", true);
		else if (animator.GetBool("IsLowLife") && Life.CurrentValue > 20)
			animator.SetBool("IsLowLife", false);
	}
}