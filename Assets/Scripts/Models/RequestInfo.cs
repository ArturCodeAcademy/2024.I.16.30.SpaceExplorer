using Newtonsoft.Json;
using System;

[Serializable]
public class RequestInfo
{
	[JsonProperty("category")]
	public string Category { get; set; }

	[JsonProperty("transactionscount")]
	public int TransactionsCount { get; set; }

	[JsonProperty("satcount")]
	public int SatCount { get; set; }
}