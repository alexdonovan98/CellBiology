using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public int length;
    private float height = 6.579999f;
    private Rigidbody2D rb;
    private Vector2 moveVelocity; 
    private SpriteRenderer sprite_renderer;
    private BoxCollider2D box_collider;

    

    // Start is called before the first frame update
    void Start()
    {
        sprite_renderer = GetComponent<SpriteRenderer>();
        box_collider = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        sprite_renderer.size = new Vector2(length * 6.55f, height);
        box_collider.size = new Vector2(length * 6.55f, height);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), 0); // move left/right by one
        moveVelocity = moveInput.normalized * speed;
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
    }

    public void SetLength(int l) {
        length = l;
        sprite_renderer.size = new Vector2(length * 6.55f, height);
        box_collider.size = new Vector2(length * 6.55f, height);
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Enemy")){
            if (length > 1) {
                length = length - 1;
                sprite_renderer.size = new Vector2(length * 6.55f, height);
                box_collider.size = new Vector2(length * 6.55f, height);
            }
        }
    }

    void DestroyPlayer() {

        Destroy(gameObject);
        Scene current_scene = SceneManager.GetActiveScene();
        if (current_scene.name == "TutorialLevel") {
            SceneManager.LoadScene("Restart");
        } else {
            SceneManager.LoadScene("Question1");
            GlobalControl.Instance.totalDamage = int.Parse(GameObject.Find("DamageCounter").GetComponent<Text>().text);

        }

    }
}
