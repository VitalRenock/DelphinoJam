using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[System.Serializable]
public class InventoryCellIconUI
{
	public GameObject GameObject;
	public RectTransform RectTransform;
	public Image Image;

	#region Constructors

	public InventoryCellIconUI(InventoryCellUI parent)
	{
		GameObject = parent.GameObject.AddChild("Content");

		RectTransform = GameObject.AddComponent<RectTransform>();
		RectTransform.anchoredPosition = Vector2.zero;
		RectTransform.sizeDelta = parent.RectTransform.sizeDelta * 0.9f;

		Image = GameObject.AddComponent<Image>();
		SetIcon();
	}

	#endregion

	public void SetIcon(Sprite sprite = null) => Image.sprite = sprite;
}