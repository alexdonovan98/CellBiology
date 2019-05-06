using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class QuestionController1 : MonoBehaviour
{
    public GameObject answers;
    public static int score;
    public GameObject questionDisplay;
    public GameObject roundEndDisplay;
    public Text finalScore;
    public Text cellNum;
    private int hint = 2;
    public Text hintText;

    void Start()
    {
        score = 0;
        Transform[] obj = (Transform[])answers.GetComponentsInChildren<Transform>();
        for (int i = 0; i < 12; i++)
        {
            if (obj[i].parent == answers.transform)
            {
                print(obj[i]);
                obj[i].SetSiblingIndex(UnityEngine.Random.Range(0,6));
            }
        }

    }

    void Update()
    {

        if(answers.transform.childCount == 0)
        {
            EndRound();
        }

    }
    public void EndRound()
    {
        score = Mathf.Max(0, score);
        GlobalControl.Instance.Q1Score = score;
        int addedCells = GlobalControl.Instance.ComputeNumCells(score);
        finalScore.text = "Score: " + score.ToString() + "/30";
        cellNum.text = "Cells: " + GlobalControl.Instance.cellGroupSize.ToString() + " (+ " + addedCells.ToString() + " cells!)";
        questionDisplay.SetActive(false);
        roundEndDisplay.SetActive(true);
    }

    public void NextLevel()
    {
        GlobalControl.Instance.Q1Score = score;
        SceneManager.LoadScene("Level2");
    }

    public void OnHint()
    {
        if(hint > 0)
        {
            hint--;
            Transform[] childs = (Transform[])answers.GetComponentsInChildren<Transform>();
            Transform randomObject = ((Transform)childs[UnityEngine.Random.Range(0, childs.Length)]);
            while(randomObject.parent != answers.transform)
            {
                randomObject = ((Transform)childs[UnityEngine.Random.Range(0, childs.Length)]);
            }

            randomObject.gameObject.GetComponent<DragTransformQ1>().Hint();
            hintText.text = "Hint " + "(" + hint.ToString() + ")";
        }

    }

}
