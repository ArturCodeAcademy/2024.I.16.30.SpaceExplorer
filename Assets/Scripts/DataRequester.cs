using Newtonsoft.Json;
using System;
using System.Net.Http;
using UnityEngine;

public class DataRequester : MonoBehaviour
{
	public bool IsDataReady { get; private set; } = false;
	public RequestResponeObject Data { get; private set; }

	private string _apiKey;

	private const string URL = "https://api.n2yo.com/rest/v1/satellite/above/{0}/{1}/{2}/{3}/{4}/&apiKey={5}";

	private async void Start()
	{
		try
		{
			_apiKey = Resources.Load<TextAsset>("api-key").text;
			string url = string.Format(URL,
										54.6872,
										25.2797,
										0,
										360,
										0,
										_apiKey);

			HttpClient client = new();
			string json = await client.GetStringAsync(url);
			Data = JsonConvert.DeserializeObject<RequestResponeObject>(json);
			IsDataReady = true;
		}
		catch (Exception e)
		{
			Debug.LogError(e.Message);
		}
	}
}