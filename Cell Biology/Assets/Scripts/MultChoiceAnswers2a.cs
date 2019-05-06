using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class MultChoiceAnswers2a : MonoBehaviour
{
    public bool isCorrect;
    public GameObject questionController;
    public GameObject hover;
    public bool hint = false;


    public void OnClick()
    {
        if (!isCorrect & !hint)
        {
            StartCoroutine(FlashColor(Color.red));
            QuestionController2.score -= 2;
        }
        else if(isCorrect)
        {
            QuestionController2.score += 10;
            questionController.GetComponent<QuestionController2>().To2B();
        }
    }
    public bool Hint()
    {
        if (isCorrect)
        {
            return false;
        }
        transform.GetComponent<Image>().color = Color.red;
        QuestionController2.score -= 2;
        hint = true;
        return true;
        
    }

    IEnumerator FlashColor(Color color)
    {
        gameObject.GetComponent<Image>().color = color;
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






