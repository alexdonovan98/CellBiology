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
    //private int numPath = 0;
    public int state = 0;
    public GameObject arrow_keys;
    public GameObject directions1;
    public GameObject directions2;
    private System.Random random = new System.Random();
    private GameObject player_inst;
    private float last_spawned = 0.0f;
    private float breakBetweenWaves = 10.0f;

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
                player_inst = Instantiate(player, new Vector3(0, -8, 0), Quaternion.identity);
                timeLeft += 4;
            }
            else if (state > 0 && state < 7)
            {
                directions2.GetComponent<Canvas>().sortingLayerName = "Text";

                if (state == 1) {
                    player_inst.GetComponent<PlayerController>().SetLength(10);
                    player_inst.transform.position = new Vector3(0, -8, 0);
                    timeLeft += 7.5f;
                } else if (state == 2) {
                    timeLeft += breakBetweenWaves;
                } else if (state == 3) {
                    player_inst.GetComponent<PlayerController>().SetLength(10);
                    player_inst.transform.position = new Vector3(0, -8, 0);
                    timeLeft += 10.0f;
                } else if (state == 4) {
                    timeLeft += breakBetweenWaves;
                } else if (state == 5) {
                    player_inst.GetComponent<PlayerController>().SetLength(5);
                    player_inst.transform.position = new Vector3(0, -8, 0);
                    timeLeft += 2.5f;
                } else if (state == 6) {
                    timeLeft += breakBetweenWaves;
                }

                arrow_keys.GetComponent<SpriteRenderer>().sortingLayerName = "Hidden";
                directions1.GetComponent<Canvas>().sortingLayerName = "Hidden";
                
            } 
            else if(state == 7)
            {
                SceneManager.LoadScene("WinScreen");
            }
            state++;
            //Debug.Log("State change: " + state);
        }
        else if (state == 2 || state == 4 || state == 6) {
            float frequency = 0.0f;
            last_spawned += Time.deltaTime;
            if (state == 2) {
                frequency = 1.5f;
            } else if (state == 4) {
                frequency = 1.0f;
            } else if (state == 6) {
                frequency = 0.5f;
            }

            if (last_spawned >= frequency) {
                SpawnPathogen();
                last_spawned = 0.0f;
            }
        } else {
            //UpdateCountdown(timeLeft);
            }

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

    private void SpawnPathogen() {
        Instantiate(pathogen, Camera.main.ViewportToWorldPoint(new Vector3((float)random.NextDouble(), 1.05f, 2)), Quaternion.identity);
    }
}