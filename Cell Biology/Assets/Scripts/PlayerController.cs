using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    public float speed;
    private Rigidbody2D rb;
    private Vector2 moveVelocity; 

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")); // move up/down/left/right by one
        moveVelocity = moveInput.normalized * speed;
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Enemy")){
            DestroyPlayer();
        }
    }

    void DestroyPlayer() {

        Destroy(gameObject);
        Scene current_scene = SceneManager.GetActiveScene();
        if (current_scene.name == "TutorialLevel") {
            SceneManager.LoadScene("Restart");
        } else {
            SceneManager.LoadScene("Questions");
        }

    }
}
