using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System;
using System.Collections;

public class QuestionController2 : MonoBehaviour
{
    public static int score;
    public GameObject question2aDisplay;
    public GameObject question2bDisplay;
    public GameObject question2cDisplay;
    public GameObject roundEndDisplay;
    public Text finalScore;
    public Text cellNum;
    public GameObject centrosomes;
    public GameObject answersA;
    public GameObject answersC;
    public Text hintTextA;
    public Text hintTextC;
    private int hintA = 1;
    private int hintC = 3;


    void Start()
    {
        score = 0;
        Transform[] obj = (Transform[])answersA.GetComponentsInChildren<Transform>();
        for (int i = 0; i < 8; i++)
        {
            if (obj[i].parent == answersA.transform)
            {
                obj[i].SetSiblingIndex(UnityEngine.Random.Range(0, 4));
            }
        }
        Transform[] obj2 = (Transform[])answersC.GetComponentsInChildren<Transform>();
        for (int i = 0; i < 20; i++)
        {
            if (obj2[i].parent == answersC.transform)
            {
                obj2[i].SetSiblingIndex(UnityEngine.Random.Range(0, 10));
            }
        }
    }

    void Update()
    {
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

    public void EndRound()
    {
        score = Mathf.Max(0, score);
        GlobalControl.Instance.Q2Score = score;
        int addedCells = GlobalControl.Instance.ComputeNumCells(score);
        finalScore.text = "Score: " + score.ToString() + "/30";
        cellNum.text = "Cells: " + GlobalControl.Instance.cellGroupSize.ToString() + " (+ " + addedCells.ToString() + " cells!)";
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
            score += 10;
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

    public void OnHintA()
    {
        if (hintA > 0)
        {
            hintA--;
            Transform[] childs = (Transform[])answersA.GetComponentsInChildren<Transform>();
            Transform randomObject = ((Transform)childs[UnityEngine.Random.Range(0, childs.Length)]);
            if (randomObject.parent == answersA.transform)
            {
                if (randomObject.gameObject.GetComponent<MultChoiceAnswers2a>().isCorrect == false &&
            randomObject.gameObject.GetComponent<MultChoiceAnswers2a>().hint == false)
                {
                    randomObject.gameObject.GetComponent<MultChoiceAnswers2a>().Hint();
                }
            }
            else
            {
                while (randomObject.parent != answersA.transform)
                {
                    randomObject = ((Transform)childs[UnityEngine.Random.Range(0, childs.Length)]);
                    if (randomObject.parent == answersA.transform)
                    {
                        randomObject.gameObject.GetComponent<MultChoiceAnswers2a>().Hint();

                    }
                }

            }
            hintTextA.text = "Hint " + "(" + hintA.ToString() + ")";
        }

    }
    public void OnHintC()
    {
        if (hintC > 0)
        {
            hintC--;
            Transform[] childs = (Transform[])answersC.GetComponentsInChildren<Transform>();
            Transform randomObject = ((Transform)childs[UnityEngine.Random.Range(0, childs.Length)]);

            while (true)
            {
                while (randomObject.parent != answersC.transform)
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

            hintTextC.text = "Hint " + "(" + hintC.ToString() + ")";
        }

    }

}
