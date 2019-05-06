using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    public float speed;
    //public int length;
    private Rigidbody2D rb;
    private Vector2 moveVelocity; 
    private SpriteRenderer sprite_renderer;
    private BoxCollider2D box_collider;
    private float height;
    private float width;

    public bool leftAble = true;
    public bool rightAble = true;

    void Awake() {
        sprite_renderer = GetComponent<SpriteRenderer>();
        box_collider = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        height = 6.911709f;
        width = 7.51125f;
    }

    // Start is called before the first frame update
    void Start() {
        sprite_renderer.size = new Vector2(width, height);
        box_collider.size = new Vector2(width, height);
    }

    // Update is called once per frame
    void Update() {
        
    }

    void FixedUpdate() {
        
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Enemy")){
            if(GlobalControl.Instance.cellGroupSize > 0)
            {
                Destroy(gameObject);
            }
        }

        if (other.name == "LeftCollider")
        {
            leftAble = false;
        }

        if (other.name == "RightCollider")
        {
            rightAble = false;
        }

    }

    void OnTriggerExit2D(Collider2D other) {
        if (other.name == "LeftCollider")
        {
            leftAble = true;
        }

        if (other.name == "RightCollider")
        {
            rightAble = true;
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
