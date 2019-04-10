using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class MultChoiceAnswers : MonoBehaviour
{
    public bool isCorrect;
    public GameObject questionController;
    public GameObject hover;

    public void OnClick()
    { 
        if (!isCorrect)
        {
            StartCoroutine(FlashColor());
            QuestionController2a.score1 -= 2;
        }
        else
        {
            QuestionController2a.score1 += 10;
            questionController.GetComponent<QuestionController2a>().EndRound();
        }
    }

    IEnumerator FlashColor()
    {
        gameObject.GetComponent<Image>().color = Color.red;
        yield return new WaitForSeconds(.5f);
        gameObject.GetComponent<Image>().color = Color.white;
    }

    public void PointerEnter()
    {
        hover.GetComponent<Outline>().enabled = true;
    }
    public void PointerExit()
    {
        hover.GetComponent<Outline>().enabled = false;
    }




}






