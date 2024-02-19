using Newtonsoft.Json;
using System;

[Serializable]
public class SateliteInfo
{
	[JsonProperty("satid")]
	public int SatId { get; set; }

	[JsonProperty("satname")]
	public string SatName { get; set; }

	[JsonProperty("intDesignator")]
	public string IntDesignator { get; set; }

	[JsonProperty("launchDate")]
	public string LaunchDate { get; set; }

	[JsonProperty("satlat")]
	public float SatLat { get; set; }

	[JsonProperty("satlng")]
	public float SatLng { get; set; }

	[JsonProperty("satalt")]
	public float SatAlt { get; set; }
}