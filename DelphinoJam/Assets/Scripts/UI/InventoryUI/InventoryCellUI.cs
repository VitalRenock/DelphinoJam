using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[System.Serializable]
public class InventoryCellUI
{
	[ReadOnly] public ItemData ItemData;

	public GameObject GameObject;
	public RectTransform RectTransform;
	public Image Image;
	public Pointable Pointable;

	public InventoryCellIconUI CellContent;

	#region Constructors

	public InventoryCellUI(InventoryUI parent)
	{
		if (parent.CellPrefab)
			GameObject = Object.Instantiate(parent.CellPrefab, parent.transform);
		else
			GameObject = parent.gameObject.AddChild();

		GameObject.name = "Cell_" + GameObject.transform.GetSiblingIndex().ToString();

		RectTransform = GameObject.GetOrAddComponent<RectTransform>();
		RectTransform.sizeDelta = parent.GridLayoutGroup.cellSize;

		Image = GameObject.GetOrAddComponent<Image>();

		Pointable = GameObject.GetOrAddComponent<Pointable>();
		Pointable.onPointerClick.AddListener(() => { InventoryManager.I.ClickedCellAction(ItemData); });

		CellContent = new InventoryCellIconUI(this);
	}

	#endregion

	public void SetItemData(ItemData itemData)
	{
		if (itemData)
		{
			ItemData = itemData;
			if (itemData.Icon)
				CellContent.SetIcon(itemData.Icon);
		}
		else
		{
			ItemData = null;
			CellContent.SetIcon();
		}
	}
}