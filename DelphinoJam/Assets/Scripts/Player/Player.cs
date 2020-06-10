using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;


[RequireComponent(typeof(RigidbodyController))]
public class Player : MonoBehaviour
{
	[ReadOnly] public PlayerState State = new PlayerState();

	[FoldoutGroup("Dependencies")]
	[ReadOnly] public RigidbodyController RigidController;
	[FoldoutGroup("Dependencies")]
	[ReadOnly] public Inventory Inventory;


	private void Awake()
	{
		RigidController = gameObject.GetOrAddComponent<RigidbodyController>();
		Inventory = gameObject.GetOrAddComponent<Inventory>();

		State = PlayerState.Standing;
	}
	private void Update() => StateManagement();
	private void OnCollisionEnter(Collision collision)
	{
		if (State == PlayerState.Jumping || State == PlayerState.DoubleJumping)
		{
			State = PlayerState.Standing;
			RigidController.jumpCount = 0;
		}
	}


	void StateManagement()
	{
		switch (State)
		{
			case PlayerState.Standing:

				#region Conditions

				if (Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Mouse X") != 0)
				{
					State = PlayerState.Moving;
					return;
				}
				if (Input.GetKeyDown(KeyCode.Space) && RigidController.jumpCount < RigidController.MaxJump)
				{
					State = PlayerState.Jumping;
					RigidController.Jump();
					return;
				}

				#endregion

				#region Actions

				#endregion

				break;

			case PlayerState.Moving:

				#region Conditions

				if (Input.GetAxis("Vertical") == 0 && Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Mouse X") == 0)
				{
					State = PlayerState.Standing;
					return;
				}
				if (Input.GetKeyDown(KeyCode.Space) && RigidController.jumpCount < RigidController.MaxJump)
				{
					State = PlayerState.Jumping;
					RigidController.Jump();
					return;
				}

				#endregion

				#region Actions

				RigidController.Move();
				RigidController.Turn();

				#endregion

				break;

			case PlayerState.Jumping:

				#region Conditions

				if (Input.GetKeyDown(KeyCode.Space) && RigidController.jumpCount < RigidController.MaxJump)
				{
					State = PlayerState.DoubleJumping;
					RigidController.Jump();
				}
				// See also OnColliderEnter()

				#endregion

				#region Actions

				//RigidController.Move();
				RigidController.Turn();

				#endregion

				break;

			case PlayerState.DoubleJumping:

				#region Conditions

				if (Input.GetKeyDown(KeyCode.Space) && RigidController.jumpCount < RigidController.MaxJump)
					RigidController.Jump();
				// See also OnColliderEnter()

				#endregion

				#region Actions

				//RigidController.Move();
				RigidController.Turn();

				#endregion

				break;

			default:
				break;
		}
	}
}

public enum PlayerState
{
	Standing,
	Moving,
	Jumping,
	DoubleJumping
}