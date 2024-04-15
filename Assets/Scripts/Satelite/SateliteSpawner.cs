using System.Collections;
using UnityEngine;

public class SateliteSpawner : MonoBehaviour
{
	[SerializeField, Min(0)] private float _maxHeight;
	[SerializeField, Min(0)] private float _minHeight;
	[SerializeField, Range(0, 1)] private float _ratio;
	[SerializeField] private Satelite _satelitePrefab;
	[SerializeField] private GameObject[] _sateliteModelPrefabs;
	[SerializeField, Min(1)] private float _limit;

	[SerializeField] private DataRequester _dataRequester;

	private IEnumerator Start()
	{
		yield return new WaitUntil(() => _dataRequester.IsDataReady);

		WaitForEndOfFrame wait = new();

		foreach (var sateliteInfo in _dataRequester.Data.Above)
		{
			if (sateliteInfo.SatAlt > _maxHeight && sateliteInfo.SatAlt < _minHeight)
				continue;

			if (0 >= _limit--)
				break;

			var satelite = Instantiate(_satelitePrefab, transform);
			Instantiate(_sateliteModelPrefabs[Random.Range(0, _sateliteModelPrefabs.Length)], satelite.transform);
			satelite.Panel.SetInfo(sateliteInfo);

			var position = Quaternion.Euler(0, 0, sateliteInfo.SatAlt) * Vector3.up * sateliteInfo.SatAlt * _ratio;
			satelite.transform.position = position;

			yield return wait;
		}
	}
}
