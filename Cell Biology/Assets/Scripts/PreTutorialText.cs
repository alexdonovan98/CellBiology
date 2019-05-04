using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PreTutorialText : MonoBehaviour
{
    public GameObject Text1;
    public GameObject Text2;
    public GameObject Text3;
    public GameObject bg;



    float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {


    }

    void Update()
    {
        timer += Time.deltaTime;
        bg.transform.position += new Vector3(0, 0.009f, 0);

        if(timer >= 17f)
        {
            SceneManager.LoadScene("TutorialLevel");

        }

        if (timer >= 12f)
        {
            Text2.SetActive(false);
            Text3.SetActive(true);
        }

        else if (timer >= 5f)
        {
            Text1.SetActive(false);
            Text2.SetActive(true);
        }


    }

}
