using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [field: SerializeField] public float MaxHealth { get; private set; }

    public float CurrentHealth { get; private set; }
    public bool IsDead => CurrentHealth <= 0;

    public event Action<float, float> HealthValueChanged;
    public event Action Died;

    private void Awake()
    {
        CurrentHealth = MaxHealth;
    }

    public void TakeDamage(float damage)
    {
        CurrentHealth -= damage;
        HealthValueChanged?.Invoke(CurrentHealth, MaxHealth);

        if (IsDead)
            Died?.Invoke();
    }

    public void Heal(float healAmount)
    {
        CurrentHealth += healAmount;
        CurrentHealth = Mathf.Min(CurrentHealth, MaxHealth);
        HealthValueChanged?.Invoke(CurrentHealth, MaxHealth);
    }

    public void Kill()
    {
		CurrentHealth = 0;
		HealthValueChanged?.Invoke(CurrentHealth, MaxHealth);
		Died?.Invoke();
	}
}