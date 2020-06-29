using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
	[TabGroup("Options")] [DisableInPlayMode] 
	public bool RemoveAfterSpawn = false;

	[TabGroup("Options")] [DisableInPlayMode] 
	public float ExpulsionForce = 100f;

	[TabGroup("Items to spawn")] [DisableInPlayMode] [AssetsOnly]
	public List<ItemData> ItemsToSpawn;

	[TabGroup("Events")] [DisableInPlayMode] 
	public ItemDataEvent onItemSpawned;

	Coroutine coroutineSpawningAllItems;


	public void SpawnFirstItem()
	{
		if (ItemsToSpawn.Count <= 0)
			return;

		InstantiateItem(ItemsToSpawn[0]);

		if (RemoveAfterSpawn)
			ItemsToSpawn.RemoveAt(0);
	}
	public void SpawnAllItems()
	{
		if (ItemsToSpawn.Count <= 0 || coroutineSpawningAllItems != null)
			return;

		coroutineSpawningAllItems = StartCoroutine(SpawningAllItems());
	}

	IEnumerator SpawningAllItems()
	{
		for (int i = 0; i < ItemsToSpawn.Count; i++)
		{
			InstantiateItem(ItemsToSpawn[i]);
			yield return new WaitForSeconds(1);
		}

		if (RemoveAfterSpawn)
			ItemsToSpawn.Clear();

		coroutineSpawningAllItems = null;
	}
	void InstantiateItem(ItemData itemData)
	{
		GameObject gameObject = Instantiate(itemData.Prefab, transform.position + Vector3.up * ((transform.localScale.y * 0.5f) + 0.5f), Quaternion.identity);
		Rigidbody rigidbody = gameObject.GetComponent<Rigidbody>();
		rigidbody.AddForce(new Vector3().RandomRange(-ExpulsionForce, ExpulsionForce), ForceMode.Acceleration);
		onItemSpawned?.Invoke(itemData);
	}
}