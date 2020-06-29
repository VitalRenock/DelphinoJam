using UnityEngine;
using Sirenix.OdinInspector;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class Item : MonoBehaviour
{
	// Add State Pattern for Collectable, Enable, ect..?

	[DisableInPlayMode] public ItemData ItemData;
	[DisableInPlayMode] public ItemEvent onItemClicked = new ItemEvent();

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.layer == LayerMask.NameToLayer("Terrain"))
		{
			Rigidbody rigidbody = GetComponent<Rigidbody>();
			rigidbody.useGravity = false;
			rigidbody.isKinematic = true;
		}
	}

	public void ClickItem() => onItemClicked?.Invoke(this);
	public void DestroyItem() => Destroy(gameObject);
}

[System.Serializable]
public class ItemEvent : UnityEvent<Item> { }