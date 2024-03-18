using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(FuelTank))]
public class RocketController : MonoBehaviour
{
	[Header("Movement")]
	[SerializeField, Min(0)] private float _movementForce = 1f;
	[SerializeField, Min(0)] private float _rotationForce = 1f;
	[SerializeField, Min(0)] private float _normalDrag = 0.1f;
	[SerializeField, Min(0)] private float _highDrag = 1f;

	[Header("Fuel usage")]
	[SerializeField, Min(0)] private float _movementFuelUsagePerSecond = 1f;
	[SerializeField, Min(0)] private float _rotationFuelUsagePerSecond = 0.1f;

	[Header("Effects")]
	[SerializeField] private ParticleSystem _movementFire;
	[SerializeField] private ParticleSystem _leftRotationFire;
	[SerializeField] private ParticleSystem _rightRotationFire;

	private Rigidbody2D _rigidbody;
	private FuelTank _fuelTank;

	private void Awake()
	{
		_rigidbody = GetComponent<Rigidbody2D>();
		_fuelTank = GetComponent<FuelTank>();
	}

	private void FixedUpdate()
	{
		_rigidbody.drag = Input.GetKey(KeyCode.Space) && _fuelTank.FuelAmount > 0
						? _highDrag
						: _normalDrag;

		if (_fuelTank.FuelAmount <= 0)
		{
			_movementFire.Stop();
			_leftRotationFire.Stop();
			_rightRotationFire.Stop();
			return;
		}

		if (Input.GetKey(KeyCode.W))
		{
			float usedFuel = _fuelTank.ConsumeFuel(_movementFuelUsagePerSecond * Time.fixedDeltaTime);
			float fuelUsageRatio = usedFuel / (_movementFuelUsagePerSecond * Time.fixedDeltaTime);
			_rigidbody.AddForce(transform.up * _movementForce * fuelUsageRatio);

			if (usedFuel > 0)
			{

				if (!_movementFire.isPlaying)
					_movementFire.Play();
			}
			else
			{
				_movementFire.Stop();
			}
		}
		else
		{
			_movementFire.Stop();
		}

		if (Input.GetKey(KeyCode.A))
		{
			float usedFuel = _fuelTank.ConsumeFuel(_rotationFuelUsagePerSecond * Time.fixedDeltaTime);
			float fuelUsageRatio = usedFuel / (_rotationFuelUsagePerSecond * Time.fixedDeltaTime);
			_rigidbody.AddTorque(_rotationForce * fuelUsageRatio);
			if (usedFuel > 0)
			{
				if (!_leftRotationFire.isPlaying)
					_leftRotationFire.Play();
			}
			else
			{
				_leftRotationFire.Stop();
			}
		}
		else
		{
			_leftRotationFire.Stop();
		}

		if (Input.GetKey(KeyCode.D))
		{
			float usedFuel = _fuelTank.ConsumeFuel(_rotationFuelUsagePerSecond * Time.fixedDeltaTime);
			float fuelUsageRatio = usedFuel / (_rotationFuelUsagePerSecond * Time.fixedDeltaTime);
			_rigidbody.AddTorque(-_rotationForce * fuelUsageRatio);
			if (usedFuel > 0)
			{
				if (!_rightRotationFire.isPlaying)
					_rightRotationFire.Play();
			}
			else
			{
				_rightRotationFire.Stop();
			}
		}
		else
		{
			_rightRotationFire.Stop();
		}
	}
}