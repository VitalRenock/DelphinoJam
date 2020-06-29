using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable][DisableInPlayMode]
public class StatsInt
{
	[TabGroup("Options")] [SerializeField] string name;
	public string Name { get => name; }

	[TabGroup("Options")] [SerializeField] int currentValue;
	public int CurrentValue { get => currentValue; }

	[TabGroup("Options")] public int MinValue;
	[TabGroup("Options")] public int MaxValue;

	[TabGroup("Events")] public StatsIntEvent onStatChanged;

	public StatsInt(string name, int value = 0, int minValue = int.MinValue, int maxValue = int.MaxValue)
	{
		SetName(name);

		currentValue = value;
		MinValue = minValue;
		MaxValue = maxValue;
		ClampValue();

		onStatChanged = new StatsIntEvent();
	}

	public void SetName(string newName) => name = newName;

	public void SetValue(int value)
	{
		currentValue = value;
		ClampValue();
		onStatChanged?.Invoke(this);
	}
	public void AddValue(int value)
	{
		currentValue += value;
		ClampValue();
		onStatChanged?.Invoke(this);
	}
	public void RemoveValue(int value)
	{
		currentValue -= value;
		ClampValue();
		onStatChanged?.Invoke(this);
	}

	public void ValueToMin() => currentValue = MinValue;
	public void ValueToMax() => currentValue = MaxValue;
	public void ValueToZero() => currentValue = 0;

	void ClampValue() => currentValue = Mathf.Clamp(currentValue, MinValue, MaxValue);
}

[System.Serializable]
public class StatsIntEvent : UnityEvent<StatsInt> { }