using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System;

public class QuestionController : MonoBehaviour
{
	public SimpleObjectPool answerButtonObjectPool;
	public Text questionText;
	public Text scoreDisplay;
    public Text timeDisplay;
    public Transform answerButtonParent;

	public GameObject questionDisplay;
	public GameObject roundEndDisplay;
    public Text totalScoreDisplay;
    public Text totalTimeDisplay;

    private DataController dataController;
	private RoundData currentRoundData;
	private QuestionData[] questionPool;

	private bool isRoundActive = false;
    private float totalTime;
    private float currentTime;
	private int playerScore;
	private int questionIndex;
	private List<GameObject> answerButtonGameObjects = new List<GameObject>();

    //treat 'rounds' as one set of questions/question for one step of mitosis
	void Start()
	{
		dataController = FindObjectOfType<DataController>();								// Store a reference to the DataController so we can request the data we need for this round

		currentRoundData = dataController.GetCurrentRoundData();							// Ask the DataController for the data for the current round. At the moment, we only have one round - but we could extend this
		questionPool = currentRoundData.questions;											// Take a copy of the questions so we could shuffle the pool or drop questions from it without affecting the original RoundData object
        totalTime = 0;
		currentTime = 0;								// Set the time limit for this round based on the RoundData object
		UpdateTimeDisplay();
		playerScore = 0;
		questionIndex = 0;

		ShowQuestion();
		isRoundActive = true;
	}

	void Update()
	{
		if (isRoundActive)
		{
			currentTime += Time.deltaTime;											
			UpdateTimeDisplay();

			//if (timeRemaining <= 0f)														// If timeRemaining is 0 or less, the round ends
			//{
			//	EndRound();
			//}
		}
    }

    private void UpdateTimeDisplay()
    {
        timeDisplay.text = Mathf.Round(currentTime).ToString();
    }

    void ShowQuestion()
	{
		RemoveAnswerButtons();

		QuestionData questionData = questionPool[questionIndex];							// Get the QuestionData for the current question
		questionText.text = questionData.questionText;										// Update questionText with the correct text

		for (int i = 0; i < questionData.answers.Length; i ++)								// For every AnswerData in the current QuestionData...
		{
			GameObject answerButtonGameObject = answerButtonObjectPool.GetObject();			// Spawn an AnswerButton from the object pool
			answerButtonGameObjects.Add(answerButtonGameObject);
			answerButtonGameObject.transform.SetParent(answerButtonParent);
			answerButtonGameObject.transform.localScale = Vector3.one;

			AnswerButton answerButton = answerButtonGameObject.GetComponent<AnswerButton>();
			answerButton.SetUp(questionData.answers[i]);									// Pass the AnswerData to the AnswerButton so the AnswerButton knows what text to display and whether it is the correct answer
		}
	}

	void RemoveAnswerButtons()
	{
		while (answerButtonGameObjects.Count > 0)											// Return all spawned AnswerButtons to the object pool
		{
			answerButtonObjectPool.ReturnObject(answerButtonGameObjects[0]);
			answerButtonGameObjects.RemoveAt(0);
		}
	}

	public void AnswerButtonClicked(bool isCorrect)
	{
        totalTime += currentTime;
        currentTime = 0;
        if (isCorrect)
		{
			playerScore += currentRoundData.pointsAddedForCorrectAnswer;					// If the AnswerButton that was clicked was the correct answer, add points
			scoreDisplay.text = playerScore.ToString();
		}

		if(questionPool.Length > questionIndex + 1)											// If there are more questions, show the next question
		{
			questionIndex++;
			ShowQuestion();
		}
		else																				// If there are no more questions, the round ends
		{
			EndRound();
            totalTimeDisplay.text = Math.Round(totalTime, 2).ToString() + " s";
            totalScoreDisplay.text = scoreDisplay.text;

        }
	}


	public void EndRound()
	{
		isRoundActive = false;

		questionDisplay.SetActive(false);
		roundEndDisplay.SetActive(true);
	}

	//public void ReturnToMenu()
	//{
	//	SceneManager.LoadScene("MenuScreen");
	//}
}