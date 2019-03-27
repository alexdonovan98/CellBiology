using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System;

public class QuestionController1 : MonoBehaviour
{
    public Text timeDisplay;
    private float currentTime;
    private List<GameObject> answerButtonGameObjects = new List<GameObject>();

    void Start()
    { 
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

    public void NextLevel()
    {
        SceneManager.LoadScene("Level1");
    }

}
