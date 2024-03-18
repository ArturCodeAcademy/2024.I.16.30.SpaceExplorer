using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Health))]
public class RocketHitDamager : MonoBehaviour
{
	[SerializeField, Min(0)] private float _damagePerVelocity = 1f;
	[SerializeField, Min(0)] private float _minVelocityToDamage = 1f;

	private Health _health;

	private void Awake()
	{
		_health = GetComponent<Health>();
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		float velocityMagnitude = collision.relativeVelocity.magnitude;
		if (velocityMagnitude < _minVelocityToDamage)
			return;

		float damage = _damagePerVelocity * velocityMagnitude;
		_health.TakeDamage(damage);
	}
}