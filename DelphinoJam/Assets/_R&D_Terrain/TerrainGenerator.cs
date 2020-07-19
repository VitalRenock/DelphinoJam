using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Sirenix.OdinInspector;

public class TerrainGenerator : MonoBehaviour
{
	TerrainData _terrainData;
	GameObject _terrainGO;
	Terrain _terrain;
	TerrainCollider _terrainCollider;

	[Header("Terrain Options")]
	public string _terrainName;
	[Tooltip("Puissance de 64 pour X et Z")] public Vector3Int _terrainSize = new Vector3Int(256, 10, 256);
	Vector2Int _terrainResolution = new Vector2Int();

	[ToggleGroup("AdjustHeight")] public bool AdjustHeight;
	[ToggleGroup("AdjustHeight")] [Range(0, 1)] public float _adjustedHeight = 0;

	[ToggleGroup("Perlin")] public bool Perlin;
	[ToggleGroup("Perlin")] public float _perlinNoiseFactor = 1;
	[ToggleGroup("Perlin")] public Vector2 _perlinOffset = Vector2.zero;

	[ToggleGroup("CustomSlope")] public bool CustomSlope;
	[ToggleGroup("CustomSlope")] public float _slopeOffsetX;
	[ToggleGroup("CustomSlope")] public float _slopeOffsetY;
	[ToggleGroup("CustomSlope")] [Range(0, 100)] public float _slopeOrientation = 0;
	[ToggleGroup("CustomSlope")] [Range(-180f, 180f)] public float _slopeAngle;

	public enum WavesMode
	{
		X,
		Z,
		Radial
	}
	[ToggleGroup("Waves")] public bool Waves;
	[ToggleGroup("Waves")] public WavesMode _wavesMode;
	[ToggleGroup("Waves")] [Range(0, 2)] public float _wavesLenght;
	[ToggleGroup("Waves")] [Range(0, 2 * Mathf.PI)] public float _wavesOffset;
	[ToggleGroup("Waves")] public float _wavesAmplitude;
	[ToggleGroup("Waves")] public float _wavesHeight;

	[ToggleGroup("RandomBumping")] public bool RandomBumping;
	[ToggleGroup("RandomBumping")] [Range(0, 0.1f)] public float _randomAmplitude = 0;

	public Vector2Int _globalOffset = new Vector2Int();


	private void OnValidate()
	{
		if (_terrainData != null)
		{
			_terrainData.name = _terrainName;
			_terrainData.size = _terrainSize;
			_terrainResolution = new Vector2Int(_terrainData.heightmapResolution, _terrainData.heightmapResolution);
			UpdateTerrain();
		}

		if(_terrainGO != null)
		_terrainGO.name = _terrainName;
	}


	[Button("Generate Terrain")]
	void GenerateTerrain()
	{
		_terrainData = new TerrainData();
		_terrainData.name = _terrainName;
		_terrainData.heightmapResolution = 513;
		_terrainData.size = _terrainSize;

		_terrainGO = Terrain.CreateTerrainGameObject(_terrainData);
		_terrainGO.name = _terrainName;

		_terrain = _terrainGO.GetComponent<Terrain>();
		_terrain.terrainData = _terrainData;

		_terrainCollider = _terrainGO.GetComponent<TerrainCollider>();
		_terrainCollider.terrainData = _terrainData;
	}

	[Button("Reset Terrain")]
	void ResetTerrain()
	{
		_terrainData.SetHeights(0, 0, new float[_terrainResolution.x, _terrainResolution.y]);
	}

	void UpdateTerrain()
	{
		//_terrainData.SetHeights(0, 0, GenerateHeights());
		_terrainData.SetHeightsDelayLOD(0, 0, GenerateHeights());
		_terrainData.SyncHeightmap();
	}

	[Button("Save Terrain")]
	void SaveTerrain()
	{
		if (!AssetDatabase.IsValidFolder("Assets/Terrains"))
			AssetDatabase.CreateFolder("Assets", "Terrains");

		AssetDatabase.CreateAsset(_terrain.terrainData, "Assets/Terrains/" + _terrainName + ".preset");
		PrefabUtility.SaveAsPrefabAsset(_terrainGO, "Assets/Terrains/" + _terrainName + ".prefab");

		AssetDatabase.Refresh();
	}


	float[,] GenerateHeights()
	{
		float[,] heights = new float[_terrainResolution.x, _terrainResolution.y];

		if (AdjustHeight)
		{
			for (int x = 0; x < _terrainResolution.x; x++)
			{
				for (int y = 0; y < _terrainResolution.y; y++)
				{
					heights[x, y] += _adjustedHeight;
				}
			}
		}

		if (Perlin)
		{
			for (int x = 0; x < _terrainResolution.x; x++)
			{
				for (int y = 0; y < _terrainResolution.y; y++)
				{
					heights[x, y] += PerlinNoise(x, y);
				}
			}
		}

		if (CustomSlope)
		{
			for (int x = 0; x < _terrainResolution.x; x++)
			{
				for (int y = 0; y < _terrainResolution.y; y++)
				{
					heights[x, y] += CustomingSlope(x, y);
				}
			}
		}

		if (Waves)
		{
			for (int x = 0; x < _terrainResolution.x; x++)
			{
				for (int y = 0; y < _terrainResolution.y; y++)
				{
					heights[x, y] += Waving(x, y);
				}
			}
		}

		if (RandomBumping)
		{
			for (int x = 0; x < _terrainResolution.x; x++)
			{
				for (int y = 0; y < _terrainResolution.y; y++)
				{
					heights[x, y] += Random.Range(0, _randomAmplitude);
				}
			}
		}

		return heights;
	}

	float PerlinNoise(int x, int y)
	{
		// Division pour que le Perlin Noise ne travaille qu'avec des décimales entre 0 et 1
		// Plus ajout d'un facteur de Zoom (_terrainScale) pour les réglages
		float xCoord = (float)x / _terrainResolution.x * _perlinNoiseFactor + _perlinOffset.x;
		float yCoord = (float)y / _terrainResolution.y * _perlinNoiseFactor + _perlinOffset.y;

		return Mathf.PerlinNoise(xCoord, yCoord);
	}

	float CustomingSlope(int x, int y)
	{
		float height;
		height = Mathf.Lerp(x + _slopeOffsetX, y + _slopeOffsetY, _slopeOrientation / 100) / _slopeAngle;

		return height;
	}

	float Waving(int x, int y)
	{
		float height = new float();

		switch (_wavesMode)
		{
			case WavesMode.X:
				height = Mathf.Cos((y * _wavesLenght) + _wavesOffset) * _wavesAmplitude + _wavesHeight;
				return height;

			case WavesMode.Z:
				height = Mathf.Cos((x * _wavesLenght) + _wavesOffset) * _wavesAmplitude + _wavesHeight;
				return height;

			case WavesMode.Radial:
				float radialFactor = Mathf.Sqrt(Mathf.Pow(x, 2) + Mathf.Pow(y, 2));
				height = Mathf.Cos((radialFactor * _wavesLenght) + _wavesOffset) * _wavesAmplitude + _wavesHeight;
				return height;

			default:
				return height;
		}
	}

	float Testing(int x, int y)
	{
		float height = 0;



		//// Hauteur
		//height = _optionTest1;

		//// Cut Axe ZX
		//height = x / (y + _optionTest1);

		//// InvertCut ZX
		//height = y / (x + _optionTest1);

		//// Slope on Axe Z
		//height = x / _optionTest1;

		//// Slope on Axe X
		//height = y / _optionTest1;

		//// Slope on Axe ZX
		//height = (x / _optionTest1) + (y / _optionTest1);

		//// Smooth Slope on Axe ZX
		//height = (x * y) / _optionTest1;

		//// Light Bumpy
		//height = Mathf.Cos(x * y) / _optionTest1;

		//// Wave Axe Z
		//height = Mathf.Sin(x + _optionTest1) * _optionTest2;

		//// Configurable Rectangle
		//height = (x + _optionTest1) / Mathf.Sqrt(y + _optionTest2);

		//// Invert Configurable Rectangle
		//height = (y + _optionTest1) / Mathf.Sqrt(x + _optionTest2);

		return height;
	}
}
