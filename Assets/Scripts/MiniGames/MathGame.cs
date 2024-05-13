using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MathGame : BaseMiniGame
{
    [SerializeField] private int _minNum;
    [SerializeField] private int _maxNum;
    [SerializeField, Min(5)] private float _timeToAnswer;

    [Space(3)]
    [SerializeField] private Image _clockFill;
    [SerializeField] private TMP_Text _questionText;
    [SerializeField] private Button[] _answerButtons;

    private float _timeLeft;

	private void Update()
	{
		_timeLeft -= Time.deltaTime;
		_clockFill.fillAmount = _timeLeft / _timeToAnswer;

		if (_timeLeft <= 0)
        {
            foreach (var button in _answerButtons)
				button.onClick.RemoveAllListeners();
			EndGame(false);
		}
	}

	public override void StartGame(RocketController controller)
    {
        base.StartGame(controller);
		float num1 = Random.Range(_minNum, _maxNum);
		float num2 = Random.Range(_minNum, _maxNum);
        Operation operation = (Operation)Random.Range(0, 4);

        _timeLeft = _timeToAnswer;

        float answer = 0;
        switch (operation)
        {
        	case Operation.Addition:
        		answer = num1 + num2;
        		_questionText.text = $"{num1} + {num2} = ?";
        		break;
        	case Operation.Subtraction:
        		answer = num1 - num2;
        		_questionText.text = $"{num1} - {num2} = ?";
        		break;
			case Operation.Division when num2 == 0:
			case Operation.Multiplication:
        		answer = num1 * num2;
        		_questionText.text = $"{num1} * {num2} = ?";
        		break;
        	case Operation.Division:
        		answer = num1 / num2;
        		_questionText.text = $"{num1} / {num2} = ?";
        		break;
        }

        int indexOfAnswer = Random.Range(0, _answerButtons.Length);
        for (int i = 0; i < _answerButtons.Length; i++)
        {
            _answerButtons[i].onClick.RemoveAllListeners();
			
            if (i == indexOfAnswer)
            {
                _answerButtons[i].onClick.AddListener(() => EndGame(true));
                _answerButtons[i].GetComponentInChildren<TMP_Text>().text = answer.ToString();
			}
			else
            {
                _answerButtons[i].onClick.AddListener(() => EndGame(false));
                _answerButtons[i].GetComponentInChildren<TMP_Text>().text =
                    Random.Range(_minNum * 2, _maxNum * 2).ToString();
			}
		}
    }

    private enum Operation
    {
		Addition,
		Subtraction,
		Multiplication,
		Division
	}
}
