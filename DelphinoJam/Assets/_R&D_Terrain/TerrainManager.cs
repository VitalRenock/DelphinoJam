using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class TerrainManager : MonoBehaviour
{
	[Header("Map options")]
	public Vector2Int _mapSize;

	[Header("Tile options")]
	public List<GameObject> _prefabsTile;
	public List<GameObject> _allTiles;
	Vector3 _tileSize;

	//NavMeshSurface _navMeshSurface;

	private void Start()
	{
		_allTiles = new List<GameObject>();
		//_navMeshSurface = GetComponent<NavMeshSurface>();


		if (_prefabsTile != null)
		{
			float tileSizeX = _prefabsTile[0].GetComponent<Terrain>().terrainData.size.x;
			float tileSizeY = _prefabsTile[0].GetComponent<Terrain>().terrainData.size.y;
			float tileSizeZ = _prefabsTile[0].GetComponent<Terrain>().terrainData.size.z;
			_tileSize = new Vector3(tileSizeX, tileSizeY, tileSizeZ);
		}
		else
			Debug.LogWarning("Liste des Prefabs Tiles vide!");

		Terrain terrain = new Terrain();
	}

	public IEnumerator InstanciateTiles()
	{
		for (int x = 0; x < _mapSize.x; x++)
		{
			for (int z = 0; z < _mapSize.y; z++)
			{
				_allTiles.Add(Instantiate(RandomTile(), new Vector3(x * _tileSize.x, 0, z * _tileSize.z), Quaternion.identity, transform));
				//yield return new WaitForSeconds(0.2f);
				yield return null;
			}
		}
	}
	GameObject RandomTile()
	{
		return _prefabsTile[Random.Range(0, _prefabsTile.Count)];
	}

	public void BakeNavMeshSurface()
	{
		//_navMeshSurface.BuildNavMesh();
	}
}
