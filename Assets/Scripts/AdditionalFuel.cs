using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdditionalFuel : MonoBehaviour
{
	[SerializeField, Min(0.01f)] private float _fuelAmount = 100f;
	[SerializeField, Min(0.01f)] private float _fillSpeed = 1f;

	[SerializeField] private Image _fill;

	private FuelTank _fuelTank;
	private float _currentFuelAmount;
	private float _maxFuelAmount;

	private void Awake()
	{
		_currentFuelAmount = _fuelAmount;
		_maxFuelAmount = _fuelAmount;
	}

	private void Update()
	{
		if (_fuelTank is null)
			return;

		float additionalFuel = Mathf.Min(_fillSpeed * Time.deltaTime, _currentFuelAmount);
		float usedFuel = _fuelTank.RefillFuel(additionalFuel);
		_currentFuelAmount -= usedFuel;
		UpdateUI();

		if (_currentFuelAmount <= 0)
			Destroy(gameObject);
	}

	private void UpdateUI()
	{
		_fill.fillAmount = _currentFuelAmount / _maxFuelAmount;
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (_fuelTank is not null)
			return;

		if (collision.TryGetComponent(out FuelTank fuelTank))
		{
			_fuelTank = fuelTank;
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.TryGetComponent(out FuelTank fuelTank) && fuelTank == _fuelTank)
		{
			_fuelTank = null;
		}
	}
}
