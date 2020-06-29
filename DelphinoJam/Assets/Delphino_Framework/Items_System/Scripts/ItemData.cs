using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
[CreateAssetMenu(fileName = "Item_X", menuName = "Delphino Framework/Item System/New Item")]
public class ItemData : ScriptableObject
{
	public string Name;
	public Sprite Icon;
	public GameObject Prefab;
}

[System.Serializable]
public class ItemDataEvent : UnityEvent<ItemData> { }