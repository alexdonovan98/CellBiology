using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System;
using System.Collections;

public class QuestionController4 : MonoBehaviour
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
        for (int i = 0; i < 8; i++)
        {
            if (obj[i].parent == answers.transform)
            {
                obj[i].SetSiblingIndex(UnityEngine.Random.Range(0, 4));
            }
        }
    }


    public void EndRound()
    {
        score = Mathf.Max(0, score);
        GlobalControl.Instance.Q4Score = score;
        int addedCells = GlobalControl.Instance.ComputeNumCells(score);
        finalScore.text = "Score: " + score.ToString() + "/30";
        cellNum.text = "Cells: " + GlobalControl.Instance.cellGroupSize.ToString() + " (+ " + addedCells.ToString() + " cells!)";
        questionDisplay.SetActive(false);
        roundEndDisplay.SetActive(true);

    }

    public void NextLevel()
    {
        GlobalControl.Instance.Q4Score = score;
        SceneManager.LoadScene("Level5");
    }
    public void OnHint()
    {
        if (hint > 0)
        {
            hint--;
            Transform[] childs = (Transform[])answers.GetComponentsInChildren<Transform>();
            Transform randomObject = ((Transform)childs[UnityEngine.Random.Range(0, childs.Length)]);
            print(randomObject);
            while (true)
            {
                while (randomObject.parent != answers.transform)
                {
                    randomObject = ((Transform)childs[UnityEngine.Random.Range(0, childs.Length)]);
                }
                if (!randomObject.gameObject.GetComponent<MultChoiceAnswers4>().hint && 
                !randomObject.gameObject.GetComponent<MultChoiceAnswers4>().isCorrect)
                {
                    break;
                }
                else
                {
                    randomObject = ((Transform)childs[UnityEngine.Random.Range(0, childs.Length)]);

                }
            }
            randomObject.gameObject.GetComponent<MultChoiceAnswers4>().Hint();

            hintText.text = "Hint " + "(" + hint.ToString() + ")";
        }

    }
}
