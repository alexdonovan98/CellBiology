using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AnswerButton : MonoBehaviour 
{
	public Text answerText;

	private QuestionController questionController;
	private AnswerData answerData;

	void Start()
	{
		questionController = FindObjectOfType<QuestionController>();
	}

	public void SetUp(AnswerData data)
	{
		answerData = data;
		answerText.text = answerData.answerText;
	}

	public void HandleClick()
	{
		questionController.AnswerButtonClicked(answerData.isCorrect);
	}
}
