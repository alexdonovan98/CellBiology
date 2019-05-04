using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class MultChoiceAnswers2c : MonoBehaviour
{
    public bool pressed = false;

    public void OnClick()
    {
        gameObject.GetComponent<Image>().color = Color.blue;
        pressed = true;
    }

    IEnumerator FlashColor()
    {
        gameObject.GetComponent<Image>().color = Color.red;
        yield return new WaitForSeconds(.5f);
        gameObject.GetComponent<Image>().color = Color.white;
    }


    public void UnPress()
    {
        gameObject.GetComponent<Image>().color = Color.white;
        pressed = false;
    }


}






