using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Sirenix.OdinInspector;

[RequireComponent(typeof(NavMeshAgent), typeof(SM_EnemyController))]
public class Enemy : MonoBehaviour
{
	// Dependencies
	[ReadOnly]
	public NavMeshAgent NavMeshAgent;
	[ReadOnly] 
	public SM_EnemyController SM_EnemyController;

	// Player
	[ReadOnly]
	public Transform Player;
	[ReadOnly]
	public float DistancePlayer;

	// Stats
	public StatsInt Life;
	public int StartLife;
	public int MinLife;
	public int MaxLife;

	// Attack
	public float AgroDistance = 10f;
	public int AttackValue = 5;
	public float AttackReloadTime = 5f;
	public float AttackDistance = 3f;

	// Heal
	public int HealValue = 5;
	public float HealReloadTime = 5f;


	private void Awake()
	{
		NavMeshAgent = GetComponent<NavMeshAgent>();
		Player = FindObjectOfType<Player>().transform;

		Life = new StatsInt("Life", StartLife, MinLife, MaxLife);
		Life.onStatChanged.AddListener(GetComponentInChildren<StatsBarUI>().UpdateBar);
	}
}