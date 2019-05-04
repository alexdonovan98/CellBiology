using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyRay : MonoBehaviour
{
    public float speed;
    public AudioSource src;
    public GameObject destroyAnim;

    void Start()
    {
        //src = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }


    void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")){
            Instantiate(destroyAnim, other.gameObject.GetComponent<Collider2D>().bounds.ClosestPoint(transform.position), Quaternion.identity);
            //AudioSource.PlayClipAtPoint(src.clip, Camera.main.transform.position, 1f);
            //Debug.Log("Played");
            DestroySelf();
        }
        else if (other.gameObject.name == "BottomCollider")
        {
            Instantiate(destroyAnim, other.gameObject.GetComponent<Collider2D>().bounds.ClosestPoint(transform.position), Quaternion.identity);
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
