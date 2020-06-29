using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[CreateAssetMenu(fileName = "ItemRecipe_New", menuName = "Delphino Framework/Item System/New Recipe")]
public class ItemRecipeData: ScriptableObject
{
	public string RecipeName;
	[AssetsOnly]
	public ItemData InputItem;
	[AssetsOnly]
	public ItemData OutputItem;
}