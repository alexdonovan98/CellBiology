using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class DragTransformQ1 : MonoBehaviour
{
    private Vector3 screenpoint;
    public GameObject correctAns;
    private Vector3 initPos;

    void OnMouseDown()
    {
        screenpoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        initPos = gameObject.transform.position;

    }

    private void OnMouseDrag()
    {
        Vector3 currentScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenpoint.z);
        Vector3 currentPos = Camera.main.ScreenToWorldPoint(currentScreenPoint);
        transform.position = currentPos;
    }

    private void OnMouseUp()
    {
        //Debug.Log("Rect: " + correctAns.GetComponent<RectTransform>().rect);
        //Debug.Log("Box2d: " + correctAns.GetComponent<BoxCollider2D>().bounds.ToString());
        //Debug.Log("Curr Mouse: " + Camera.main.ScreenToWorldPoint(Input.mousePosition));

       if (correctAns.GetComponent<BoxCollider2D>().bounds.Contains(Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenpoint.z))))
        //if (correctAns.GetComponent<RectTransform>().rect.Contains(Camera.main.ScreenToWorldPoint(Input.mousePosition)))
        {
            transform.SetParent(correctAns.transform);
            QuestionController1.score += 8;
        }
        else
        {
            StartCoroutine(FlashColor());
            QuestionController1.score -= 2;

        }
    }

    IEnumerator FlashColor()
    {
        transform.position = initPos;
        gameObject.GetComponent<Image>().color = Color.red;
        yield return new WaitForSeconds(.5f);
        gameObject.GetComponent<Image>().color = Color.white;
    }
}






