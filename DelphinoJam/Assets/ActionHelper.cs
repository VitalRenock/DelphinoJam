using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ActionHelper : MonoBehaviour
{
	public delegate void deleg();
	public event deleg sendDeleg;


	public void Essai(int a, int b, int c, int d)
	{
		Debug.Log("Essai" + a + b + c + d);

		sendDeleg += Essai2;
		sendDeleg.DynamicInvoke();
	}
	void Essai2()
	{
		Debug.Log("Hello");
	}
}