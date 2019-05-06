using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System;
using System.Collections;

public class QuestionController5 : MonoBehaviour
{
    public static int score;
    public GameObject questionDisplay;
    public GameObject roundEndDisplay;
    public Text finalScore;
    public Text cellNum;
    public GameObject answers;
    public Text hintText;
    public int hint = 1;


    void Start()
    {
        score = 0;
        Transform[] obj = (Transform[])answers.GetComponentsInChildren<Transform>();
        for (int i = 0; i < 20; i++)
        {
            if (obj[i].parent == answers.transform)
            {
                obj[i].SetSiblingIndex(UnityEngine.Random.Range(0, 10));
            }
        }
    }

    public void EndRound()
    {
        score = Mathf.Max(0, score);
        GlobalControl.Instance.Q5Score = score;
        int addedCells = GlobalControl.Instance.ComputeNumCells(score);
        finalScore.text = "Score: " + score.ToString() + "/30";
        cellNum.text = "Cells: " + GlobalControl.Instance.cellGroupSize.ToString() + " (+ " + addedCells.ToString() + " cells!)";
        questionDisplay.SetActive(false);
        roundEndDisplay.SetActive(true);
    }

    public void NextLevel()
    {
        GlobalControl.Instance.Q5Score = score;
        SceneManager.LoadScene("End");
    }

    public void OnSubmit()
    {
        if (GameObject.Find("AnswerT1").GetComponent<MultChoiceAnswers2c>().pressed == true &&
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
            score += 30;
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
    public void OnHint()
    {
        if (hint > 0)
        {
            hint--;
            score -= 2;
            Transform[] childs = (Transform[])answers.GetComponentsInChildren<Transform>();
            Transform randomObject = ((Transform)childs[UnityEngine.Random.Range(0, childs.Length)]);

            while (true)
            {
                while (randomObject.parent != answers.transform)
                {
                    randomObject = ((Transform)childs[UnityEngine.Random.Range(0, childs.Length)]);
                }
                if (!randomObject.gameObject.GetComponent<MultChoiceAnswers2c>().hint)
                {
                    break;
                }
                else
                {
                    randomObject = ((Transform)childs[UnityEngine.Random.Range(0, childs.Length)]);

                }
            }
            randomObject.gameObject.GetComponent<MultChoiceAnswers2c>().Hint();

            hintText.text = "Hint " + "(" + hint.ToString() + ")";
        }

    }
}
