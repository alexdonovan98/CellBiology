using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class FinalScore : MonoBehaviour
{
    public Text finalScore;

    void Start()
    {
        //if ((GlobalControl.Instance.Q1Score + GlobalControl.Instance.Q2Score + GlobalControl.Instance.Q3Score + GlobalControl.Instance.Q4Score + GlobalControl.Instance.Q5Score) - GlobalControl.Instance.totalDamage) <= 0) {
          //  finalScore.text = "Your final score is 0";
        //} else {
        finalScore.text = "Your final score is " + ((GlobalControl.Instance.Q1Score + GlobalControl.Instance.Q2Score + GlobalControl.Instance.Q3Score + GlobalControl.Instance.Q4Score + GlobalControl.Instance.Q5Score) - GlobalControl.Instance.totalDamage).ToString();
        //}
    }
}
