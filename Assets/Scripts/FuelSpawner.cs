using System.Collections;
using UnityEngine;

public class FuelSpawner : MonoBehaviour
{
	[SerializeField] private RocketController _rocket;

	[SerializeField] private GameObject _fuelPrefab;
	[SerializeField] private float _minSpawnDistance = 30f;
	[SerializeField] private float _maxSpawnDistance = 60f;
	[SerializeField] private float _initialSpawnInterval = 20f;
	[SerializeField] private float _lifetime = 60f;
	[SerializeField] private int _initialCount = 10;

	private float _timer;
	private Rigidbody2D _rocketRigidbody;

	private void Awake()
	{
		_rocketRigidbody = _rocket.GetComponent<Rigidbody2D>();
	}

	private IEnumerator Start()
	{
		WaitForSeconds wait = new(_initialSpawnInterval);
		for (int i = 0; i < _initialCount; i++)
		{
			Spawn();
			yield return wait;
		}
	}

	private void Update()
	{
		_timer -= Time.deltaTime;
		if (_timer <= 0)
			Spawn();
	}

	private void Spawn()
	{
		GameObject fuel = Instantiate(_fuelPrefab, transform);
		Vector3 position = _rocketRigidbody.velocity.normalized;
		if (position == Vector3.zero)
			position = Random.insideUnitCircle.normalized;

		position *= Random.Range(_minSpawnDistance, _maxSpawnDistance);
		fuel.transform.position = _rocket.transform.position + position;
		Destroy(fuel, _lifetime);
		_timer = _lifetime;
	}
}