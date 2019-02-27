using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;
using UnityEngine.SceneManagement;
using System;

public class TutorialLevel : MonoBehaviour
{
    public float timeLeft = 2.0f;
    public Text countdown;
    public GameObject player;
    public GameObject pathogen;
    private GameObject[] pathogenInstances;
    private int numPath = 0;
    public int state = 0;
    public GameObject arrow_keys;
    public GameObject directions1;
    public GameObject directions2;


    private void Start()
    {
        pathogenInstances = new GameObject[30];
        arrow_keys = GameObject.Find("Arrow Keys");
        directions1 = GameObject.Find("Directions1");
        directions2 = GameObject.Find("Directions2");
    }

    void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        { 
            if (state == 0)
            {
                GameObject player_inst = Instantiate(player, new Vector3(0, 0, 0), Quaternion.identity);
                timeLeft += 4;

            }
            else if (state > 0 && state < 3)
            {
                directions2.GetComponent<Canvas>().sortingLayerName = "Text";

                pathogenInstances[numPath] = Instantiate(pathogen, Camera.main.ViewportToWorldPoint(new Vector3(1, 1, 0)), Quaternion.identity);
                pathogenInstances[numPath+1] = Instantiate(pathogen, Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 0)), Quaternion.identity);
                pathogenInstances[numPath+2] = Instantiate(pathogen, Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0)), Quaternion.identity);
                pathogenInstances[numPath+3] = Instantiate(pathogen, Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)), Quaternion.identity);
                numPath += 4;
                for (int i = 0; i < numPath; i++)
                {
                    pathogenInstances[i].GetComponent<EnemyFollow>().speed += 0.2f;
                }
                arrow_keys.GetComponent<SpriteRenderer>().sortingLayerName = "Hidden";
                directions1.GetComponent<Canvas>().sortingLayerName = "Hidden";
                timeLeft += 10;
            }
            else if(state == 3)
            {
                pathogenInstances[numPath] = Instantiate(pathogen, Camera.main.ViewportToWorldPoint(new Vector3(1, 1, 0)), Quaternion.identity);
                pathogenInstances[numPath + 1] = Instantiate(pathogen, Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 0)), Quaternion.identity);
                pathogenInstances[numPath + 2] = Instantiate(pathogen, Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0)), Quaternion.identity);
                pathogenInstances[numPath + 3] = Instantiate(pathogen, Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)), Quaternion.identity);
                pathogenInstances[numPath + 4] = Instantiate(pathogen, Camera.main.ViewportToWorldPoint(new Vector3(1, 0.5f, 0)), Quaternion.identity);
                pathogenInstances[numPath + 5] = Instantiate(pathogen, Camera.main.ViewportToWorldPoint(new Vector3(0, 0.5f, 0)), Quaternion.identity);
                pathogenInstances[numPath + 6] = Instantiate(pathogen, Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0, 0)), Quaternion.identity);
                pathogenInstances[numPath + 7] = Instantiate(pathogen, Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 1, 0)), Quaternion.identity);
                pathogenInstances[numPath + 8] = Instantiate(pathogen, Camera.main.ViewportToWorldPoint(new Vector3(0.25f, 0, 0)), Quaternion.identity);
                pathogenInstances[numPath + 9] = Instantiate(pathogen, Camera.main.ViewportToWorldPoint(new Vector3(0.75f, 1, 0)), Quaternion.identity);
                pathogenInstances[numPath + 10] = Instantiate(pathogen, Camera.main.ViewportToWorldPoint(new Vector3(1, 0.25f, 0)), Quaternion.identity);
                pathogenInstances[numPath + 11] = Instantiate(pathogen, Camera.main.ViewportToWorldPoint(new Vector3(1, 0.75f, 0)), Quaternion.identity);
                pathogenInstances[numPath + 12] = Instantiate(pathogen, Camera.main.ViewportToWorldPoint(new Vector3(0.75f, 1, 0)), Quaternion.identity);
                pathogenInstances[numPath + 13] = Instantiate(pathogen, Camera.main.ViewportToWorldPoint(new Vector3(0.25f, 1, 0)), Quaternion.identity);
                pathogenInstances[numPath + 14] = Instantiate(pathogen, Camera.main.ViewportToWorldPoint(new Vector3(0, 0.25f, 0)), Quaternion.identity);
                pathogenInstances[numPath + 15] = Instantiate(pathogen, Camera.main.ViewportToWorldPoint(new Vector3(0, 0.75f, 0)), Quaternion.identity);
                numPath += 15;
                for (int i = 0; i < numPath; i++)
                {
                    pathogenInstances[i].GetComponent<EnemyFollow>().speed += 0.4f;
                }
                timeLeft += 15;

            }
            else if(state == 4)
            {
                SceneManager.LoadScene("WinScreen");
            }
            state++;

        }
        else if(state > 1)
            UpdateCountdown(timeLeft);

    }


    private void UpdateCountdown(float totalSeconds)
    {
        int minutes = Mathf.FloorToInt(totalSeconds / 60f);
        int seconds = Mathf.RoundToInt(totalSeconds % 60f);

        string formatedSeconds = seconds.ToString();

        if (seconds == 60)
        {
            seconds = 0;
            minutes += 1;
        }

        countdown.text = "Time Remaining: " + minutes.ToString("00") + ":" + seconds.ToString("00");
    }
}