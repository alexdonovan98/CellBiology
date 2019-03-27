using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DragTransform : MonoBehaviour
{
    private Vector3 screenpoint;

    void OnMouseDown()
    {
        screenpoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
    }

    private void OnMouseDrag()
    {
        Vector3 currentScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenpoint.z);
        Vector3 currentPos = Camera.main.ScreenToWorldPoint(currentScreenPoint);
        transform.position = currentPos;
    }

}