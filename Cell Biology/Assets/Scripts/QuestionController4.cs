using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System;
using System.Collections;

public class QuestionController4 : MonoBehaviour
{
    public Text timeDisplay;
    private float currentTime;
    public static int score;
    public GameObject questionDisplay;
    public GameObject roundEndDisplay;
    public Text finalTime; 
    public Text finalScore;


    void Start()
    {
        score = 0;
        currentTime = 0;
        UpdateTimeDisplay();
}

    void Update()
    {
        currentTime += Time.deltaTime;
        UpdateTimeDisplay();
    }

    private void UpdateTimeDisplay()
    {
        timeDisplay.text = Mathf.Round(currentTime).ToString();
    }
    public void EndRound()
    {
        score = Mathf.Max(0, score);
        GlobalControl.Instance.Q4Score = score;
        int addedCells = GlobalControl.Instance.ComputeNumCells(score);
        finalScore.text = score.ToString() + " (+ " + addedCells.ToString() + " cells)";
        finalTime.text = Math.Round(currentTime, 4).ToString();
        questionDisplay.SetActive(false);
        roundEndDisplay.SetActive(true);
    }

    public void NextLevel()
    {
        GlobalControl.Instance.Q2Score += score;
        SceneManager.LoadScene("Level5");
    }
}
