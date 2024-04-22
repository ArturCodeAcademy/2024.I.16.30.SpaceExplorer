using UnityEngine;
using UnityEngine.Events;

public class BaseMiniGame : MonoBehaviour
{
	public UnityEvent GameFinishedSuccessfully;
	public UnityEvent GameFinishedUnsuccessfully;

	private Rigidbody2D _rocketRb;

	private void Awake()
	{
		GameFinishedSuccessfully ??= new UnityEvent();
		GameFinishedUnsuccessfully ??= new UnityEvent();
	}

	public virtual void StartGame(RocketController controller)
	{
		gameObject.SetActive(true);
	}

	protected void EndGame(bool success)
	{
		if (success)
			GameFinishedSuccessfully?.Invoke();
		else
			GameFinishedUnsuccessfully?.Invoke();

		gameObject.SetActive(false);
	}
}
