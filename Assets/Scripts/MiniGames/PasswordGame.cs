using TMPro;
using UnityEngine;

public class PasswordGame : BaseMiniGame
{
	[SerializeField] private TMP_Text _passwordText;
	[SerializeField] private TMP_Text _inputText;

	private string _password;
	private string _input;

	private const int MAX_DIGITS = 4;

	public override void StartGame(RocketController controller)
	{
		base.StartGame(controller);
		_password = Random.Range(0, 10000).ToString("0000");
		_passwordText.text = _password;
		_inputText.text = "____";
		_input = string.Empty;
	}

	public void AddDigit(int digit)
	{
		if (_input.Length < MAX_DIGITS)
		{
			_input += digit;
			_inputText.text = _input + new string('_', MAX_DIGITS - _input.Length);
		}
	}

	public void RemoveLetter()
	{
		if (_input.Length > 0)
		{
			_input = _input.Remove(_input.Length - 1);
			_inputText.text = _input + new string('_', MAX_DIGITS - _input.Length);
		}
	}

	public void CheckPassword()
	{
		if (_input == _password)
			EndGame(true);
		else
			EndGame(false);
	}
}
