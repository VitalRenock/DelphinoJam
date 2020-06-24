using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(GridLayoutGroup))]
public class InventoryUI : MonoBehaviour
{
	[FoldoutGroup("Needed References")]
	[SceneObjectsOnly] public Inventory InventoryTarget;
	[FoldoutGroup("Needed References")]
	[AssetsOnly] public GameObject CellPrefab;

	[FoldoutGroup("Debug")]
	[ReadOnly] public List<InventoryCellUI> Cells;

	[FoldoutGroup("Dependencies")]
	[ReadOnly] public GridLayoutGroup GridLayoutGroup;

	private void Awake() => GridLayoutGroup = gameObject.GetOrAddComponent<GridLayoutGroup>();

	public void UpdateCells()
	{
		DestroyCells();
		GenerateAllCells();
		FillCells();
	}

	void GenerateCell() => Cells.Add(new InventoryCellUI(this));
	void GenerateAllCells()
	{
		for (int i = 0; i < InventoryTarget.MaxSize; i++)
			GenerateCell();
	}

	void DestroyCell(InventoryCellUI inventoryCell)
	{
		if (Cells.Contains(inventoryCell))
		{
			Destroy(inventoryCell.GameObject);
			Cells.Remove(inventoryCell);
		}
	}
	void DestroyCells()
	{
		for (int i = 0; i < Cells.Count; i++)
			Destroy(Cells[i].GameObject);

		Cells.Clear();
	}

	void FillCells()
	{
		if (InventoryTarget)
			for (int i = 0; i < InventoryTarget.Items.Count; i++)
				Cells[i].SetItemData(InventoryTarget.Items[i]);
		else
			Debug.LogWarning("FillCells(): No Inventory Target");
	}
}