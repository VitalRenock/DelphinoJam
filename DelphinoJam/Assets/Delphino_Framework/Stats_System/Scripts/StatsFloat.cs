using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable][DisableInPlayMode]
public class StatsFloat
{
	[TabGroup("Options")] [SerializeField] string name;
	public string Name { get => name; }

	[TabGroup("Options")] [SerializeField] [ReadOnly]
	float currentValue;
	public float CurrentValue { get => currentValue; }

	[TabGroup("Options")] public float StartValue;
	[TabGroup("Options")] public float MinValue;
	[TabGroup("Options")] public float MaxValue;

	[TabGroup("Events")] public StatsFloatEvent onStatChanged;

	public StatsFloat(string name, float startValue, float minValue = float.MinValue, float maxValue = float.MaxValue)
	{
		SetName(name);
		StartValue = startValue;
		MinValue = minValue;
		MaxValue = maxValue;

		ValueToStart();
		ClampValue();

		onStatChanged = new StatsFloatEvent();
	}

	public void SetName(string newName) => name = newName;

	public void SetValue(float value)
	{
		currentValue = value;
		ClampValue();
		onStatChanged?.Invoke(this);
	}
	public void AddValue(float value)
	{
		currentValue += value;
		ClampValue();
		onStatChanged?.Invoke(this);
	}
	public void RemoveValue(float value)
	{
		currentValue -= value;
		ClampValue();
		onStatChanged?.Invoke(this);
	}

	public void ValueToMin() => currentValue = MinValue;
	public void ValueToMax() => currentValue = MaxValue;
	public void ValueToZero() => currentValue = 0f;
	public void ValueToStart() => currentValue = StartValue;

	void ClampValue() => currentValue = Mathf.Clamp(currentValue, MinValue, MaxValue);
}

[System.Serializable]
public class StatsFloatEvent : UnityEvent<StatsFloat> { }