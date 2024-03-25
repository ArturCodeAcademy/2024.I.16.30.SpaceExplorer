using UnityEngine;

public class DestroyOnEndHealth : MonoBehaviour
{
	[SerializeField] private Health _health;
	[SerializeField] private Transform _explosionPrefab;

	private void OnEnable()
	{
		_health.Died += Destroy;
	}

	private void OnDisable()
	{
		_health.Died -= Destroy;
	}

	private void Destroy()
	{
		if (_explosionPrefab != null)
			Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
		Destroy(gameObject);
	}
}
