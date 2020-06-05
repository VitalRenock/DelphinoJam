using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Sirenix.OdinInspector;


public class SpotItem : MonoBehaviour
{
	[TabGroup("Item")]
	public ItemData ItemOnResource;
	[TabGroup("Item")]
	public GameObject PrefabItem;

	[TabGroup("Events")]
	public UnityEvent OnSpawnResource;
}