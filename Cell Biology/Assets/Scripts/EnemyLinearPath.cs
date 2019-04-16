using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyLinearPath : MonoBehaviour
{
    public float speed;
    public AudioSource tickSource;

    void Start()
    {
        tickSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision) // Not sure if I need a collision or trigger method so I added a collsion method
    {
        if(collision.gameObject.tag == "Player")
        {
            tickSource.Play();
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")){
            tickSource.Play();
            DestroySelf();
        }
        else if (other.gameObject.name == "BottomCollider")
        {
            int damageCount = int.Parse(GameObject.Find("DamageCounter").GetComponent<Text>().text);
            DestroySelf();
            damageCount++;
            GameObject.Find("DamageCounter").GetComponent<Text>().text = damageCount.ToString();

        }
    }

 
    void DestroySelf() {

        Destroy(gameObject);

    }
}
