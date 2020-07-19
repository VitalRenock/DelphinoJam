using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[RequireComponent(typeof(Terrain))]
public class TerrainSpawner : MonoBehaviour
{
	[AssetsOnly]
	public List<GameObject> PrefabsToSpawn;
	public int AmountToSpawn;
	[SceneObjectsOnly]
	public Transform ParentForSpawnedObjects;

	Terrain terrain;
	TerrainData terrainData;
	[ShowInInspector] [ReadOnly]
	List<GameObject> spawnedGameObjects = new List<GameObject>();

	private void Reset()
	{
		terrain = GetComponent<Terrain>();
		terrainData = terrain.terrainData;
	}

	[Button("Spawn")]
	void Spawn()
	{
		if (PrefabsToSpawn.Count > 0)
			for (int i = 0; i < AmountToSpawn; i++)
			{
				GameObject gameObject = PrefabsToSpawn[Random.Range(0, PrefabsToSpawn.Count - 1)];
				Vector3 height = GetRandomPositionOnTerrain() + new Vector3(0, gameObject.transform.localScale.y * 0.5f, 0);
				spawnedGameObjects.Add(Instantiate(gameObject, height, Quaternion.identity, ParentForSpawnedObjects));
			}
	}

	[Button("Destroy")]
	void Destroy()
	{
		for (int i = 0; i < spawnedGameObjects.Count; i++)
			DestroyImmediate(spawnedGameObjects[i]);

		spawnedGameObjects.Clear();
	}

	Vector3 GetRandomPositionOnTerrain()
	{
		float xPos = Random.Range(0f, terrainData.size.x);
		float zPos = Random.Range(0f, terrainData.size.z);
		float yPos = terrain.SampleHeight(new Vector3(xPos, 0, zPos));
		//float yPos = terrainData.GetHeight((int)xPos, (int)zPos);
		return new Vector3(xPos, yPos, zPos);
	}
}