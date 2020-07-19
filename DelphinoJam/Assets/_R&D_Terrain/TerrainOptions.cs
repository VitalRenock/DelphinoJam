using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Sirenix.OdinInspector;

[RequireComponent(typeof(Terrain))]
[RequireComponent(typeof(TerrainCollider))]
public class TerrainOptions : MonoBehaviour
{
	public Terrain _terrain;
	public TerrainData _terrainData;
	public TerrainCollider _terrainCollider;
	Vector3 _terrainSize;

	[Header("Perlin Noise Options")]
	public int _perlinNoiseFactor = 1;
	public float _perlinOffsetX = 100f;
	public float _perlinOffsetY = 100f;
	[Header("Perlin Noise Animation")]
	public bool _perlinAnimatedOnX = false;
	public bool _perlinAnimatedOnY = false;
	public float _perlinSpeedAnimation = 1f;

	private void OnValidate()
	{
		_terrain = GetComponent<Terrain>();
		_terrainData = _terrain.terrainData;
		//_terrain.terrainData = _terrainData;
		_terrainCollider = GetComponent<TerrainCollider>();
		_terrainSize = _terrain.terrainData.size;
	}

	private void Update()
	{
		UpdateTerrain();

		if (_perlinAnimatedOnX)
			_perlinOffsetX += Time.deltaTime * _perlinSpeedAnimation;
		if (_perlinAnimatedOnY)
			_perlinOffsetY += Time.deltaTime * _perlinSpeedAnimation;
	}

	[Button("Update Options")]
	void UpdateTerrain()
	{
		/*_terrain.*/_terrainData.SetHeights(0, 0, GenerateHeights());
		_terrain.terrainData = _terrainData;
		_terrainCollider.terrainData = _terrainData;
	}
	float[,] GenerateHeights()
	{
		float[,] heights = new float[(int)_terrainSize.x, (int)_terrainSize.z];

		// On parcours chaque point de la grille pour définir la hauteur
		for (int x = 0; x < _terrainSize.x; x++)
		{
			for (int y = 0; y < _terrainSize.z; y++)
			{
				heights[x, y] = PerlinNoise(x, y);
			}
		}

		return heights;
	}
	float PerlinNoise(int x, int y)
	{
		// Division pour que le Perlin Noise ne travaille qu'avec des décimales entre 0 et 1
		// Plus ajout d'un facteur de Zoom (_terrainScale) pour les réglages
		float xCoord = (float)x / _terrainSize.x * _perlinNoiseFactor + _perlinOffsetX;
		float yCoord = (float)y / _terrainSize.z * _perlinNoiseFactor + _perlinOffsetY;

		return Mathf.PerlinNoise(xCoord, yCoord);
	}
}
