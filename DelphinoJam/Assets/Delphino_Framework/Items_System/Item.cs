using UnityEngine;
using Sirenix.OdinInspector;
using UnityEngine.EventSystems;
using UnityEngine.Events;

[RequireComponent(typeof(Pointable))]
public class Item : MonoBehaviour
{
	[DisableInPlayMode] public ItemData ItemData;
	public ItemEvent onItemClicked = new ItemEvent();

	public void ClickItem() => onItemClicked?.Invoke(this);
	public void DestroyItem() => Destroy(gameObject);
}

[System.Serializable]
public class ItemEvent : UnityEvent<Item> { }

// Add State Pattern for Collectable, Enable, ect...