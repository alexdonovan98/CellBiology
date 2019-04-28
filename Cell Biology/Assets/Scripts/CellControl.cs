using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellControl : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    private Vector2 moveVelocity;
    private SpriteRenderer sprite_renderer;
    private CompositeCollider2D composite_collider;


    void Awake() {
        sprite_renderer = GetComponent<SpriteRenderer>();
        composite_collider = GetComponent<CompositeCollider2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        //Physics2D.IgnoreCollision(transform.parent.GetComponent<BoxCollider2D>(), GetComponent<CircleCollider2D>());

    }

    // Update is called once per frame
    void Update()
    {
        //Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), 0);
        //moveVelocity = moveInput.normalized * speed;
        //Vector3 direction = (transform.parent.position - transform.position).normalized;

        //rb.AddForce(rb.mass * (200 * direction));

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
            //GetComponentInParent<CellGroupScript>().UpdateGrid();
        }
    }
}
