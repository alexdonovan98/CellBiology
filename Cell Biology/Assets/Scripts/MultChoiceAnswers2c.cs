using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class MultChoiceAnswers2c : MonoBehaviour
{
    public bool pressed = false;
    public bool hint = false;
    public bool isCorrect;

    public void OnClick()
    {
        if (!hint)
        {
            if (!pressed)
            {
                gameObject.GetComponent<Image>().color = Color.green;
                pressed = true;
            }
            else
            {
                gameObject.GetComponent<Image>().color = Color.white;
                pressed = false;
            }
        }
    }

    IEnumerator FlashColor(Color color)
    {
        gameObject.GetComponent<Image>().color = color;
        yield return new WaitForSeconds(.5f);
        gameObject.GetComponent<Image>().color = Color.white;
    }


    public void UnPress()
    {
        if (!hint && pressed && !isCorrect)
        {
            StartCoroutine(FlashColor(Color.red));
            pressed = false;
        }
    }

    public void Hint()
    {
        if (!hint)
        {
            if (isCorrect)
            {
                transform.GetComponent<Image>().color = Color.green;
                pressed = true;
            }
            else
            {
                transform.GetComponent<Image>().color = Color.red;
            }
            QuestionController2.score -= 2;
            hint = true;

        }
    }
}






