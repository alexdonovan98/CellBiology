using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System;

public class QuestionController3 : MonoBehaviour
{
    public static int score;
    public GameObject questionDisplay;
    public GameObject roundEndDisplay;
    public Text finalScore;
    public Text cellNum;

    void Start()
    {
        score = 0;
    }

    public void EndRound()
    {
        score = Mathf.Max(0, score);
        GlobalControl.Instance.Q3Score = score;
        int addedCells = GlobalControl.Instance.ComputeNumCells(score);
        finalScore.text = "Score: " + score.ToString() + "/30";
        cellNum.text = "Cells: " + GlobalControl.Instance.cellGroupSize.ToString() + " (+ " + addedCells.ToString() + " cells!)";
        questionDisplay.SetActive(false);
        roundEndDisplay.SetActive(true);
    }

    public void NextLevel()
    {
        GlobalControl.Instance.Q1Score = score;
        SceneManager.LoadScene("Level4");
    }

    public void OnSubmit()
    {
        if (GameObject.Find("Answer1").GetComponent<MultChoiceAnswers2c>().pressed == true &&
            GameObject.Find("Answer2").GetComponent<MultChoiceAnswers2c>().pressed == true &&
            GameObject.Find("Answer3").GetComponent<MultChoiceAnswers2c>().pressed == true &&
            GameObject.Find("Answer4").GetComponent<MultChoiceAnswers2c>().pressed == true)
        {
            score += 30;
            EndRound();
        }
        else
        {
            GameObject.Find("Answer1").GetComponent<MultChoiceAnswers2c>().UnPress();
            GameObject.Find("Answer2").GetComponent<MultChoiceAnswers2c>().UnPress();
            GameObject.Find("Answer3").GetComponent<MultChoiceAnswers2c>().UnPress();
            GameObject.Find("Answer4").GetComponent<MultChoiceAnswers2c>().UnPress();
            score -= 2;
        }
    }

}
