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
        Transform[] obj = answers.GetComponentsInChildren<Transform>();
        for(int i = 0; i < 12; i++)
        {
            if (obj[i].parent == answers)
            {
                print(obj[i]);
                obj[i].SetAsLastSibling();
            }
        }

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
        score = Mathf.Max(0, score);
        GlobalControl.Instance.Q1Score = score;
        int addedCells = GlobalControl.Instance.ComputeNumCells(score);
        finalScore.text = score.ToString() + " (+ " + addedCells.ToString() + " cells)";
        finalTime.text = Math.Round(currentTime, 4).ToString();
        questionDisplay.SetActive(false);
        roundEndDisplay.SetActive(true);
    }

    public void NextLevel()
    {
        GlobalControl.Instance.Q1Score = score;
        SceneManager.LoadScene("Level2");
    }

}
