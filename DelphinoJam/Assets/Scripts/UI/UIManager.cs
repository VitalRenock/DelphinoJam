using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Sirenix.OdinInspector;


public class UIManager : Singleton<UIManager>
{
	public SuperUIInventory InventoryPanel;

	public void OpenCloseInventoryPanel()
	{
		InventoryPanel.gameObject.SetActive(!InventoryPanel.gameObject.activeSelf);
		InventoryPanel.UpdateSlots(PlayerManager.I.GameObjectLoaded.GetComponent<Player>().Inventory);
	}
}