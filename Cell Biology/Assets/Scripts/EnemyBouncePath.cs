using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class EnemyBouncePath : MonoBehaviour
{
    public float speed;
    public float slope;
    private Transform target;
    private System.Random random = new System.Random();
    private AudioSource src;
    public GameObject destroyAnim;




    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        slope = (float)random.NextDouble() * Time.deltaTime * 20;
        int random_direction = random.Next(0, 2);
        if (random_direction == 0) {
            slope = -slope;
        }
        src = GetComponent<AudioSource>();
    }

    void Update()
    {
        transform.Translate(0.3f * slope, -speed*Time.deltaTime, 0);

    }

    void DestroySelf() {

        Destroy(gameObject);

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Border")
        {
            slope = -slope;
        }

        else if (other.gameObject.name == "BottomCollider")
        {
            Instantiate(destroyAnim, other.gameObject.GetComponent<Collider2D>().bounds.ClosestPoint(transform.position), Quaternion.identity);
            int damageCount = int.Parse(GameObject.Find("DamageCounter").GetComponent<Text>().text);
            DestroySelf();
            damageCount++;
            GameObject.Find("DamageCounter").GetComponent<Text>().text = damageCount.ToString();
        }
        else if (other.gameObject.tag == "Player")
        {
            Instantiate(destroyAnim, other.gameObject.GetComponent<Collider2D>().bounds.ClosestPoint(transform.position), Quaternion.identity);
            AudioSource.PlayClipAtPoint(src.clip, Camera.main.transform.position, 1f);
            DestroySelf();
        }
    }
}
