using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CellGroupScript : MonoBehaviour
{
    public int size;
    public Camera cam;
    public GameObject cell;
    private int maxLength;
    private GameObject[] obj;
    private Vector3[] pos;
    private float cellwidth;
    private float cellheight;
    public float speed;
    private Rigidbody2D rb;
    private Vector2 moveVelocity;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // cellInstances = new GameObject[size];
        // maxLength = (int)(cam.GetComponent<RectTransform>().rect.width / cell.GetComponent<SpriteRenderer>().size.x);
        // GridLayoutGroup grid = GetComponent<GridLayoutGroup>();
        // grid.cellSize = cell.GetComponent<SpriteRenderer>().size;
        ////Debug.Log(cam.GetComponent<RectTransform>().rect.width);
        //Debug.Log(cell.GetComponent<SpriteRenderer>().size.x);
        //Debug.Log(maxLength);
        //maxLength = 4;
        //grid.constraintCount = maxLength;
        cellwidth = cell.GetComponent<SpriteRenderer>().size.x;
        cellheight = cell.GetComponent<SpriteRenderer>().size.y;
        Debug.Log(cellwidth);
        Debug.Log(cellheight);

        maxLength = 6;
        size = 20;
        obj = new GameObject[size];
        pos = new Vector3[obj.Length];

        for (int i = 0; i < size; i++)
        {
            int x = (i % maxLength);
            int y = (int)Mathf.Floor(i / maxLength);
            //Debug.Log(i);
            //Debug.Log(x);
            //Debug.Log(y);
            Debug.Log(transform.position);
            pos[i] = new Vector3(transform.position.x+x, transform.position.y+y, 0);
            obj[i] = Instantiate(cell, pos[i], transform.rotation);
            obj[i].transform.SetParent(transform);
        }

        //for (int y = 0; y < (int)obj.Length/maxLength; y++)
        //{
        //    for(int x=0; x < maxLength; x++)
        //    {
        //        if(y*maxLength + x < size)
        //        {
        //            pos[y*maxLength + x] = new Vector3(transform.position.x + x, transform.position.y + y, 0);
        //            obj[y * maxLength + x] = Instantiate(cell, pos[y * maxLength + x], transform.rotation);
        //        }
        //    }

        //    //pos[0] = new Vector3(transform.position.x + i, transform.position.y, transform.position.z);
        //    //pos[1] = new Vector3(transform.position.x + i, transform.position.y - 1, transform.position.z);
        //    ////etc...
        //    //Instantiate(obj[i], pos[1], transform.rotation);
        //    ////etc...
        //}
    }
        //for(int j=0; j < (int)(size/maxLength); j++)
        //{
        //    for (int k=0; k < maxLength; k++)
        //    {
        //        cellInstances[j*maxLength + k] = Instantiate(cell, grid.transform, false);
        //        cellInstances[j * maxLength + k].transform.Translate(0.3f,0, 0);

        //    }
        //}
//        for (int i = 0; i < size; i++)
//        {
//            cellInstances[i] = Instantiate(cell, grid.transform, false);
//        }

    



    public void UpdateGrid()
    {

    }

    void Update()
    {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), 0);
        moveVelocity = moveInput.normalized * speed;

        //rb.AddForce(transform.parent.position - transform.position);
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
    }
}
