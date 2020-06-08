using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class Player : MonoBehaviour
{
	public float MoveSpeed = 1;
	public float TurnSpeed = 1;
	public float JumpSpeed = 1;
	public int MaxJump = 1;
	public int jumpCount = 0;

	[ReadOnly] public PlayerState State = new PlayerState();
	[ReadOnly] public Rigidbody Rigidbody;
	[ReadOnly] public Inventory Inventory = new Inventory() { Size = 30};

	private void Awake()
	{
		Rigidbody = GetComponent<Rigidbody>();

		State = PlayerState.Standing;
	}

	private void Update() => StateManagement();
	//private void Update()
	//{
	//	StateManagement();

	//	if (Input.GetKeyDown(KeyCode.Tab))
	//		UIManager.I.OpenCloseInventoryPanel();

	//	if (Input.GetKeyDown(KeyCode.Alpha0))
	//		ItemManager.I.CreateItem(PlayerManager.I.TestItem, PlayerManager.I.TestPosition);
	//}
	private void OnCollisionEnter(Collision collision)
	{
		if (State == PlayerState.Jumping || State == PlayerState.DoubleJumping)
		{
			State = PlayerState.Standing;
			jumpCount = 0;
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
				if (Input.GetKeyDown(KeyCode.Space) && jumpCount < MaxJump)
				{
					State = PlayerState.Jumping;
					Jump();
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
				if (Input.GetKeyDown(KeyCode.Space) && jumpCount < MaxJump)
				{
					State = PlayerState.Jumping;
					Jump();
					return;
				}

				#endregion

				#region Actions

				Move();
				Turn();

				#endregion

				break;

			case PlayerState.Jumping:

				#region Conditions

				if (Input.GetKeyDown(KeyCode.Space) && jumpCount < MaxJump)
				{
					State = PlayerState.DoubleJumping;
					Jump();
				}
				// See also OnColliderEnter()

				#endregion

				#region Actions

				Move();
				Turn();

				#endregion

				break;

			case PlayerState.DoubleJumping:

				#region Conditions

				if (Input.GetKeyDown(KeyCode.Space) && jumpCount < MaxJump)
					Jump();
				// See also OnColliderEnter()

				#endregion

				#region Actions

				Move();
				Turn();

				#endregion

				break;

			default:
				break;
		}
	}
	void Move() => Rigidbody.AddRelativeForce(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * MoveSpeed, ForceMode.Force);
	void Turn() => Rigidbody.AddRelativeTorque(new Vector3(0, Mathf.Clamp(Input.GetAxis("Mouse X"), -1, 1), 0) * TurnSpeed, ForceMode.VelocityChange);
	void Jump()
	{
		jumpCount++;
		Rigidbody.AddRelativeForce(Vector3.up * JumpSpeed, ForceMode.Impulse);
	}
}

public enum PlayerState
{
	Standing,
	Moving,
	Jumping,
	DoubleJumping
}