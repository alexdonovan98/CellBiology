using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class DragTransformQ1 : MonoBehaviour
{
    private Vector3 screenpoint;
    public GameObject correctAns;
    public GameObject incorrectAns;
    private Vector3 initPos;
    private bool hint = false;

    public void Hint()
    {
        transform.SetParent(correctAns.transform);
        transform.GetComponent<Image>().color = Color.green;
        QuestionController1.score -= 2;
        hint = true;
    }

    void OnMouseDown()
    {
        if (!hint)
        {
            screenpoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
            initPos = gameObject.transform.position;
        }

    }

    private void OnMouseDrag()
    {
        if (!hint)
        {
            Vector3 currentScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenpoint.z);
            Vector3 currentPos = Camera.main.ScreenToWorldPoint(currentScreenPoint);
            transform.position = currentPos;
        }
    }

    private void OnMouseUp()
    {
        if (!hint)
        {
            if (correctAns.GetComponent<BoxCollider2D>().bounds.Contains(Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenpoint.z))))
            {
                transform.SetParent(correctAns.transform);
                StartCoroutine(FlashColor(Color.green));
                QuestionController1.score += 5;
            }
            else if (incorrectAns.GetComponent<BoxCollider2D>().bounds.Contains(Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenpoint.z))))
            {
                StartCoroutine(FlashColor(Color.red));
                QuestionController1.score -= 2;
            }
            else
            {
                StartCoroutine(FlashColor(Color.red));
            }
        }

    }

    IEnumerator FlashColor(Color color)
    {
        transform.position = initPos;
        gameObject.GetComponent<Image>().color = color;
        yield return new WaitForSeconds(.5f);
        gameObject.GetComponent<Image>().color = Color.white;
    }
}






