using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellControl : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    private Vector2 moveVelocity;
    private SpriteRenderer sprite_renderer;
    private CircleCollider2D circle_collider;


    // Start is called before the first frame update
    void Start()
    {
        sprite_renderer = GetComponent<SpriteRenderer>();
        circle_collider = GetComponent<CircleCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        Physics2D.IgnoreCollision(transform.parent.GetComponent<BoxCollider2D>(), GetComponent<CircleCollider2D>());

    }

    // Update is called once per frame
    void Update()
    {
        //Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), 0);
        //moveVelocity = moveInput.normalized * speed;
        Vector3 direction = (transform.parent.position - transform.position).normalized;

        rb.AddForce(rb.mass * (200 * direction));

        //rb.AddForce((transform.parent.position - transform.position).normalized * 100 * Time.smoothDeltaTime);
        //        Debug.Log("parent:" + transform.parent.position);
        //Debug.Log("position:" + transform.position);
    }

    void FixedUpdate()
    {
        //rb.AddForce((transform.parent.position - transform.position).normalized * 100 * Time.smoothDeltaTime);

        //rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            GetComponentInParent<CellGroupScript>().UpdateGrid();
        }
    }
}
