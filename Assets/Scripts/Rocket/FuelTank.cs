using System;
using UnityEngine;

public class FuelTank : MonoBehaviour
{
	[field: SerializeField, Min(0)] public float FuelAmount = 100f;
	[field: SerializeField, Min(0)] public float TankVolume = 100f;

	public Action<float, float> FuelValueChanged;

	public float ConsumeFuel(float amount)
	{
		float fuelConsumed = Mathf.Min(FuelAmount, amount);
		FuelAmount -= fuelConsumed;
		FuelValueChanged?.Invoke(FuelAmount, TankVolume);
		return fuelConsumed;
	}

	public float RefillFuel(float amount)
	{
		float fuelRefilled = Mathf.Min(TankVolume - FuelAmount, amount);
		FuelAmount += fuelRefilled;
		FuelValueChanged?.Invoke(FuelAmount, TankVolume);
		return fuelRefilled;
	}
}