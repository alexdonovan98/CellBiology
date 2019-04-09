using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
