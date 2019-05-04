using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyLinearPath : MonoBehaviour
{
    public float speed;
    public AudioSource src;
    public GameObject damage;

    void Start()
    {
        src = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }


    void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")){
            AudioSource.PlayClipAtPoint(src.clip, Camera.main.transform.position, 1f);
            DestroySelf();
            Vector3 pt = other.gameObject.GetComponent<Collider>().ClosestPointOnBounds(transform.position);
            Instantiate(damage, pt, Quaternion.identity);

        }
        else if (other.gameObject.name == "BottomCollider")
        {
            int damageCount = int.Parse(GameObject.Find("DamageCounter").GetComponent<Text>().text);
            DestroySelf();
            damageCount++;
            GameObject.Find("DamageCounter").GetComponent<Text>().text = damageCount.ToString();
            Vector3 pt = other.gameObject.GetComponent<Collider>().ClosestPointOnBounds(transform.position);
            Instantiate(damage, pt, Quaternion.identity);

        }
    }

 
    void DestroySelf() {

        Destroy(gameObject);

    }
}
