using TMPro;
using UnityEngine;

public class SpeedUI : MonoBehaviour
{
	[SerializeField] private TMP_Text _speedText;
	[SerializeField] private Transform _dirrectionArrow;

	[SerializeField] private Rigidbody2D _rigidbody2D;

	private void FixedUpdate()
	{
		_speedText.text = $"{_rigidbody2D.velocity.magnitude:F2} km / h";
		_dirrectionArrow.up = _rigidbody2D.velocity.normalized;
	}
}
