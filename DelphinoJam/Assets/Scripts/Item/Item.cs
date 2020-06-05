using UnityEngine;
using Sirenix.OdinInspector;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Pointable))]
public class Item : MonoBehaviour
{
	[DisableInPlayMode] public ItemData ItemData;
	[ReadOnly] public Pointable Interactable;


	private void Awake()
	{
		Interactable = GetComponent<Pointable>();

		Interactable.PointerClickAction += GiveItem;
	}


	public void GiveItem(PointerEventData eventData)
	{
		bool isGived = PlayerManager.I.GameObjectLoaded.GetComponent<Player>().Inventory.AddItem(ItemData);

		if (isGived)
			DestroyItem();
	}
	public void DestroyItem()
	{
		Destroy(gameObject);
	}
}