using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System;
using System.Collections;

public class QuestionController2 : MonoBehaviour
{
    public Text timeDisplay;
    private float currentTime;
    public static int score;
    public GameObject question2aDisplay;
    public GameObject question2bDisplay;
    public GameObject question2cDisplay;
    public GameObject roundEndDisplay;
    public Text finalTime;
    public Text finalScore;
    public GameObject centrosomes;


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
        if (question2bDisplay.activeInHierarchy && centrosomes.transform.childCount == 0)
        {
            MyDelay(2);
            To2C();
        }
    }

    internal void To2B()
    {
        question2aDisplay.SetActive(false);
        question2bDisplay.SetActive(true);
    }
    internal void To2C()
    {
        question2bDisplay.SetActive(false);
        question2cDisplay.SetActive(true);
    }

    private void UpdateTimeDisplay()
    {
        timeDisplay.text = Mathf.Round(currentTime).ToString();
    }
    public void EndRound()
    {
        score = Mathf.Max(0, score);
        GlobalControl.Instance.Q2Score = score;
        int addedCells = GlobalControl.Instance.ComputeNumCells(score);
        finalScore.text = score.ToString() + " (+ " + addedCells.ToString() + " cells)";
        finalTime.text = Math.Round(currentTime, 4).ToString();
        question2cDisplay.SetActive(false);
        roundEndDisplay.SetActive(true);
    }

    public void NextLevel()
    {
        GlobalControl.Instance.Q2Score += score;
        SceneManager.LoadScene("Level3");
    }

    public void On2CSubmit()
    {
        if(GameObject.Find("AnswerT1").GetComponent<MultChoiceAnswers2c>().pressed == true &&
            GameObject.Find("AnswerT2").GetComponent<MultChoiceAnswers2c>().pressed == true &&
            GameObject.Find("AnswerT3").GetComponent<MultChoiceAnswers2c>().pressed == true &&
            GameObject.Find("AnswerT4").GetComponent<MultChoiceAnswers2c>().pressed == true &&
            GameObject.Find("AnswerT5").GetComponent<MultChoiceAnswers2c>().pressed == true &&
            GameObject.Find("AnswerF1").GetComponent<MultChoiceAnswers2c>().pressed == false &&
            GameObject.Find("AnswerF3").GetComponent<MultChoiceAnswers2c>().pressed == false &&
            GameObject.Find("AnswerF3").GetComponent<MultChoiceAnswers2c>().pressed == false &&
            GameObject.Find("AnswerF4").GetComponent<MultChoiceAnswers2c>().pressed == false &&
            GameObject.Find("AnswerF5").GetComponent<MultChoiceAnswers2c>().pressed == false)
        {
            score += 25;
            EndRound();
        }
        else
        {
            GameObject.Find("AnswerT1").GetComponent<MultChoiceAnswers2c>().UnPress();
            GameObject.Find("AnswerT2").GetComponent<MultChoiceAnswers2c>().UnPress();
            GameObject.Find("AnswerT3").GetComponent<MultChoiceAnswers2c>().UnPress();
            GameObject.Find("AnswerT4").GetComponent<MultChoiceAnswers2c>().UnPress();
            GameObject.Find("AnswerT5").GetComponent<MultChoiceAnswers2c>().UnPress();
            GameObject.Find("AnswerF1").GetComponent<MultChoiceAnswers2c>().UnPress();
            GameObject.Find("AnswerF2").GetComponent<MultChoiceAnswers2c>().UnPress();
            GameObject.Find("AnswerF3").GetComponent<MultChoiceAnswers2c>().UnPress();
            GameObject.Find("AnswerF4").GetComponent<MultChoiceAnswers2c>().UnPress();
            GameObject.Find("AnswerF5").GetComponent<MultChoiceAnswers2c>().UnPress();
            score -= 2;
        }
    }

    public static void MyDelay(int seconds)
    {
        var ts = DateTime.Now + TimeSpan.FromSeconds(seconds);

        do { } while (DateTime.Now < ts);
    }

}
