using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[CreateAssetMenu(fileName = "Item_X", menuName = "Datas/New Item")]
public class ItemData : ScriptableObject
{
	public string Name;
	public Sprite Icon;
	public GameObject Prefab;
}