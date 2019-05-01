using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellControl : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    private Vector2 moveVelocity;
    //private SpriteRenderer sprite_renderer;
    private CompositeCollider2D composite_collider;
    //private BoxCollider2D box_collider;
    //private float height;
    //private float width;
    private bool canMoveLeft = true;
    private bool canMoveRight = true;

    //private GameObject[,] cellArray;

    void Awake() {
        //sprite_renderer = GetComponent<SpriteRenderer>();
        composite_collider = GetComponent<CompositeCollider2D>();
        //box_collider = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        //height = 6.911709f;
        //width = 7.51125f;
    }

    // Start is called before the first frame update
    void Start()
    {
        //sprite_renderer.size = new Vector2(width * 1, height * 1);
        //box_collider.size = new Vector2(width * 1, height * 1);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), 0); // move left/right by one
        moveVelocity = moveInput.normalized * speed;

        canMoveLeft = true;
        canMoveRight = true;
        foreach (Transform child in transform) {
            if (!child.GetComponent<PlayerController>().leftAble) {
                canMoveLeft = false;
            }
            if (!child.GetComponent<PlayerController>().rightAble) {
                canMoveRight = false;
            }
        }
        
    }

    void FixedUpdate()
    {
        if (canMoveLeft && moveVelocity.x <= 0) {
            //rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
            foreach (Transform child in transform) {
                Rigidbody2D crb = child.GetComponent<Rigidbody2D>();
                crb.MovePosition(crb.position + moveVelocity * Time.fixedDeltaTime);
            }
        } else if (canMoveRight && moveVelocity.x >= 0) {
            //rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
            foreach (Transform child in transform) {
                Rigidbody2D crb = child.GetComponent<Rigidbody2D>();
                crb.MovePosition(crb.position + moveVelocity * Time.fixedDeltaTime);
            }
        }
    }


    /* void UpdateCells(GameObject[,] array) {
        cellArray = array;
    } */

    /* void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "LeftCollider")
        {
            canMoveLeft = false;
        }

        if (other.name == "RightCollider")
        {
            canMoveRight = false;
        }
    }

    void OnTriggerExit2D(Collider2D other) {

        if (other.name == "LeftCollider")
        {
            canMoveLeft = true;
        }

        if (other.name == "RightCollider")
        {
            canMoveRight = true;
        }
    } */
}
