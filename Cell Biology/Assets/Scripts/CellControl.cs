using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellControl : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    private Vector2 moveVelocity;
    private CompositeCollider2D composite_collider;

    private bool canMoveLeft = true;
    private bool canMoveRight = true;

    //private GameObject[,] cellArray;

    void Awake() {
        composite_collider = GetComponent<CompositeCollider2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
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
            foreach (Transform child in transform) {
                Rigidbody2D crb = child.GetComponent<Rigidbody2D>();
                crb.MovePosition(crb.position + moveVelocity * Time.fixedDeltaTime);
            }
        } else if (canMoveRight && moveVelocity.x >= 0) {
            foreach (Transform child in transform) {
                Rigidbody2D crb = child.GetComponent<Rigidbody2D>();
                crb.MovePosition(crb.position + moveVelocity * Time.fixedDeltaTime);
            }
        }
    }

}
