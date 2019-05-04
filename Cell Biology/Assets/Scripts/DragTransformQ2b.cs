using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class DragTransformQ2b : MonoBehaviour
{
    private Vector3 screenpoint;
    public GameObject correctPosition1;
    public GameObject correctPosition2;
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

        if (correctPosition1.GetComponent<BoxCollider2D>().bounds.Contains(Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenpoint.z)))
        && correctPosition1.transform.childCount == 0)
        //if (correctAns.GetComponent<RectTransform>().rect.Contains(Camera.main.ScreenToWorldPoint(Input.mousePosition)))
        {
            transform.SetParent(correctPosition1.transform);
            QuestionController2.score += 5;
        }
        else if (correctPosition2.GetComponent<BoxCollider2D>().bounds.Contains(Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenpoint.z)))
&& correctPosition2.transform.childCount == 0)
        {
            transform.SetParent(correctPosition2.transform);
            QuestionController2.score += 5;
        }
        else
        {
            StartCoroutine(FlashColor());
            QuestionController2.score -= 2;

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






