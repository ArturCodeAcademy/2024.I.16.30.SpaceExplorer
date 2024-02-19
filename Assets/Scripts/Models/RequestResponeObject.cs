using Newtonsoft.Json;
using System;

[Serializable]
public class RequestResponeObject
{
	[JsonProperty("info")]
	public RequestInfo Info { get; set; }

	[JsonProperty("above")]
	public SateliteInfo[] Above { get; set; }
}