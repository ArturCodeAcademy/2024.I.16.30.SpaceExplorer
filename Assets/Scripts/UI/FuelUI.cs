using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FuelUI : MonoBehaviour
{
    [SerializeField] private Image _fill;
    [SerializeField] private TMP_Text _text;
    [SerializeField] private string _format = "{0:0.00}";

    [Space(5)]
    [SerializeField] private FuelTank _fuelTank;

    private void Start()
    {
        OnFuelValueChanged(_fuelTank.FuelAmount, _fuelTank.TankVolume);
    }

    private void OnEnable()
    {
        _fuelTank.FuelValueChanged += OnFuelValueChanged;
    }

    private void OnDisable()
    {
        _fuelTank.FuelValueChanged -= OnFuelValueChanged;
    }

    private void OnFuelValueChanged(float fuelAmount, float tankVolume)
    {
        float fuelUsageRatio = fuelAmount / tankVolume;
        _fill.fillAmount = fuelUsageRatio;
        _text.text = string.Format(_format, fuelAmount, tankVolume, fuelUsageRatio * 100);
    }
}