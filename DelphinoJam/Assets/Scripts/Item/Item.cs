using UnityEngine;
using Sirenix.OdinInspector;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Pointable))]
public class Item : MonoBehaviour
{
	[DisableInPlayMode] public ItemData ItemData;
	[ReadOnly] public Pointable Pointable;


	private void Awake()
	{
		Pointable = gameObject.GetOrAddComponent<Pointable>();

		Pointable.PointerClickAction += GiveItem;
	}

	// Add State Pattern for Collectable, Enable, ect...?
	public void GiveItem(PointerEventData eventData)
	{
		// !!! Temporary
		bool isGived = FindObjectOfType<Player>().Inventory.AddItem(ItemData);

		if (isGived)
			DestroyItem();
	}
	public void DestroyItem()
	{
		Destroy(gameObject);
	}
}