using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "Item_X", menuName = "Datas/New Item")]
public class ItemData : ScriptableObject
{
	public string Name;
	public Sprite Icon;
	public GameObject Prefab;
}

public class ItemDataEvent : UnityEvent<ItemData> { }