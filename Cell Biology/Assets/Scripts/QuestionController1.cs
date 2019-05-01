using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System;

public class QuestionController1 : MonoBehaviour
{
    public Text timeDisplay;
    private float currentTime;
    public GameObject answers;
    public static int score1;
    public GameObject questionDisplay;
    public GameObject roundEndDisplay;
    public Text finalTime;
    public Text finalScore;

    void Start()
    {
        score1 = 0;
        currentTime = 0;                                
        UpdateTimeDisplay();
    }

    void Update()
    {
        currentTime += Time.deltaTime;
        UpdateTimeDisplay();
        if(answers.transform.childCount == 0)
        {
            EndRound();
        }

    }

    private void UpdateTimeDisplay()
    {
        timeDisplay.text = Mathf.Round(currentTime).ToString();
    }
    public void EndRound()
    {
        finalScore.text = score1.ToString();
        finalTime.text = Math.Round(currentTime, 4).ToString();
        questionDisplay.SetActive(false);
        roundEndDisplay.SetActive(true);
    }

    public void NextLevel()
    {
        GlobalControl.Instance.Q1Score = score1;
        SceneManager.LoadScene("Level2");
    }

}
