using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(GridLayoutGroup))]
public class InventoryUI : MonoBehaviour
{
	[FoldoutGroup("Needed References")]
	[SceneObjectsOnly]public Inventory InventoryTarget;
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
		GenerateCells();
		FillCells();
	}
	void GenerateCells()
	{
		DestroyCells();

		if (CellPrefab)
			for (int i = 0; i < InventoryTarget.MaxSize; i++)
				Cells.Add(new InventoryCellUI(this));
		else
			for (int i = 0; i < InventoryTarget.MaxSize; i++)
				Cells.Add(new InventoryCellUI(this));
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