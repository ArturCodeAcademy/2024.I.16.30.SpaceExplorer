using TMPro;
using UnityEngine;

public class SateliteInfoPanel : MonoBehaviour
{
	[SerializeField] private TMP_Text _idText;
	[SerializeField] private TMP_Text _nameText;
	[SerializeField] private TMP_Text _launchDateText;

	public void SetInfo(SateliteInfo satelite)
	{
		_idText.text = satelite.SatId.ToString();
		_nameText.text = satelite.SatName;
		_launchDateText.text = satelite.LaunchDate;
	}
}