using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class FinalScore : MonoBehaviour
{
    public Text finalScore;
    public Text qScoreSum;
    public Text damage;
   
    void Start()
    {
        qScoreSum.text = "Sum of question scores: " + (GlobalControl.Instance.Q1Score + GlobalControl.Instance.Q2Score + GlobalControl.Instance.Q3Score + GlobalControl.Instance.Q4Score + GlobalControl.Instance.Q5Score).ToString();
        damage.text = "- Damage penalty: " + GlobalControl.Instance.totalDamage.ToString();
        finalScore.text = "Your final score is: " + ((GlobalControl.Instance.Q1Score + GlobalControl.Instance.Q2Score + GlobalControl.Instance.Q3Score + GlobalControl.Instance.Q4Score + GlobalControl.Instance.Q5Score) - GlobalControl.Instance.totalDamage).ToString();
    }
}
