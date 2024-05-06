using UnityEngine;

public class Interaction : MonoBehaviour
{
	private RocketController _rocketController;
	private BaseMiniGame _miniGame;

	private void Update()
	{
		if (_rocketController is null)
			return;

		if (Input.GetKeyDown(KeyCode.E))
		{
			_rocketController.enabled = false;
			_rocketController.transform.parent = transform;
			if (_rocketController.TryGetComponent(out Rigidbody2D rb))
			{
				rb.velocity = Vector2.zero;
				rb.angularVelocity = 0;
				rb.bodyType = RigidbodyType2D.Kinematic;
			}

			_miniGame = MiniGamePool.Instance.GetRandomGame();
			_miniGame.StartGame(_rocketController);
			_miniGame.GameFinishedSuccessfully.AddListener(OnFinishSuccesfully);
			_miniGame.GameFinishedUnsuccessfully.AddListener(OnFinishUnsuccesfully);
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		_rocketController = collision.GetComponent<RocketController>();
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (_rocketController == collision.GetComponent<RocketController>())
			_rocketController = null;
	}

	private void OnFinishSuccesfully()
	{
		Finish();

		_rocketController.GetComponentInChildren<SateLiteSelector>().SelectRandomSatelite();
		Destroy(gameObject);
	}

	private void OnFinishUnsuccesfully()
	{
		Finish();

		GetComponentInParent<Health>().Kill();
	}

	private void Finish()
	{
		_miniGame.GameFinishedUnsuccessfully.RemoveListener(OnFinishUnsuccesfully);
		_miniGame.GameFinishedUnsuccessfully.RemoveListener(OnFinishSuccesfully);
		_rocketController.enabled = true;
		_rocketController.transform.parent = null;
		_rocketController.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
	}
}