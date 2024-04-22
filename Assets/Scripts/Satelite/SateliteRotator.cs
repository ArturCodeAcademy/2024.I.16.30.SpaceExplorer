using UnityEngine;

public class SateliteRotator : MonoBehaviour
{
	[SerializeField] private float _minRotationSpeed;
	[SerializeField] private float _maxRotationSpeed;
	[SerializeField] private float _impulse = 10;

	private float _rotationSpeed;

	private void Start()
	{
		if (_minRotationSpeed > _maxRotationSpeed)
			(_minRotationSpeed, _maxRotationSpeed) = (_maxRotationSpeed, _minRotationSpeed);

		_rotationSpeed = Random.Range(_minRotationSpeed, _maxRotationSpeed);
	}

	private void Update()
	{
		transform.RotateAround(Vector3.zero, Vector3.forward, _rotationSpeed * Time.deltaTime);
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		collision.rigidbody?.AddForce(collision.contacts[0].normal * _impulse, ForceMode2D.Impulse);
		Destroy(this);
	}
}
