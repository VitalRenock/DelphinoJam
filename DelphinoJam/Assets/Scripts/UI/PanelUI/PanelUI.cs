using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;


public class PanelUI : MonoBehaviour
{
	public UnityEvent onOpenPanel;
	public UnityEvent onClosePanel;

	public void DisplayPanel(bool display = true)
	{
		if (display)
			onOpenPanel?.Invoke();
		else
			onClosePanel?.Invoke();

		gameObject.SetActive(display);
	}
	public void TogglePanel() => DisplayPanel(!gameObject.activeSelf);
}