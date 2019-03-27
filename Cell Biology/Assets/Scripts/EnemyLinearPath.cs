using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLinearPath : MonoBehaviour
{
    public float speed;


    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")){
            DestroySelf();
        }
    }

    void DestroySelf() {

        Destroy(gameObject);

    }
}
