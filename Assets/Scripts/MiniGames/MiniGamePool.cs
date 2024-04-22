using UnityEngine;

public class MiniGamePool : MonoBehaviour
{
	public static MiniGamePool Instance { get; private set; }

	private BaseMiniGame[] _miniGames;

	private void Awake()
	{
		Instance = this;
		_miniGames = GetComponentsInChildren<BaseMiniGame>();

		foreach (var game in _miniGames)
		{
			game.gameObject.SetActive(false);
		}
	}

	public BaseMiniGame GetRandomGame()
	{
		return _miniGames[Random.Range(0, _miniGames.Length)];
	}
}
