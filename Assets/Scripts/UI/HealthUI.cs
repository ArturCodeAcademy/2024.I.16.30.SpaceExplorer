using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{

    [SerializeField] private Image _fill;
    [SerializeField] private TMP_Text _text;
    [SerializeField] private bool _useGradient;
    [SerializeField] private Gradient _gradient;
    [SerializeField] private string _format = "{0:0.00}";

    [Space(5)]
    [SerializeField] private Health _health;

    private void Start()
    {
        OnFuelValueChanged(_health.CurrentHealth, _health.MaxHealth);
    }

    private void OnEnable()
    {
        _health.HealthValueChanged += OnFuelValueChanged;
    }

    private void OnDisable()
    {
        _health.HealthValueChanged -= OnFuelValueChanged;
    }

    private void OnFuelValueChanged(float current, float max)
    {
        float percent = current / max;

        if (_fill != null)
            _fill.fillAmount = percent;

        if (_text != null)
            _text.text = string.Format(_format, current, max, percent * 100);

        if (_useGradient && _fill != null)
            _fill.color = _gradient.Evaluate(percent);
    }
}