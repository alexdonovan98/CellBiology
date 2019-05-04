using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class MultChoiceAnswers4 : MonoBehaviour
{
    public bool isCorrect;
    public GameObject questionController;
    public GameObject hover;

    public void OnClick()
    { 
        if (!isCorrect)
        {
            StartCoroutine(FlashColor());
            QuestionController4.score -= 2;
        }
        else
        {
            QuestionController4.score += 20;
            questionController.GetComponent<QuestionController4>().EndRound();
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






