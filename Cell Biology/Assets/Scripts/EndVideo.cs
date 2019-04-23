using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EndVideo : MonoBehaviour
{
    public float timer = 54;
    
    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if(timer <= 0)
        {
            SceneManager.LoadScene("TutorialLevel");
        }
    }
}
