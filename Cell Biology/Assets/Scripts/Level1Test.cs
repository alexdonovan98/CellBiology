﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;
using UnityEngine.SceneManagement;
using System;

public class Level1Test : MonoBehaviour
{
    public float timeLeft = 2.0f;
    public Text countdown;
    public GameObject player;
    public GameObject bouncing_pathogen;
    public GameObject linear_pathogen;
    private GameObject[] pathogenInstances;
    //private int numPath = 0;
    public int state = 0;
   
    public GameObject directions2;
    private System.Random random = new System.Random();

    enum Pathogen {bouncing, linear};
    private int _next_spawn = 0;
    //private GameObject player_inst;
    private float last_spawned = 0.0f;
    private float breakBetweenWaves = 10.0f;

    private int _columns;
    private int _rows;
    public int numCells;
    private int _num_left_to_spawn;
    //public GameObject player;
    public GameObject gridParent;

    private GameObject grid_instance;

    private GameObject[,] cells;


    private void Start()
    {
        pathogenInstances = new GameObject[30];
        
        directions2 = GameObject.Find("Directions2");
        //player_inst = Instantiate(player, new Vector3(0, -8, 0), Quaternion.identity);

        numCells = 11;
        GlobalControl.Instance.cellGroupSize = numCells;

        _num_left_to_spawn = numCells;
        if (numCells >= 8) {
            _columns = 8;
        } else {
            _columns = numCells;
        }
        _rows = (int) Math.Ceiling(numCells / 8.0);
        cells = new GameObject[_rows, _columns];

        float spawn_x = -5.0f;
        float spawn_y = -8.0f;
        grid_instance = Instantiate(gridParent, new Vector3(0, -8, 0), Quaternion.identity);
        for(int i = 0; i < _rows; i++) {
            for(int j = 0; j < _columns; j++) {
                //Debug.Log(i + ", " + j);
                if (_num_left_to_spawn > 0) {
                    cells[i,j] = Instantiate(player, new Vector3(spawn_x, spawn_y, 0), Quaternion.identity);
                    cells[i,j].transform.parent = grid_instance.transform;
                    spawn_x += 2.75f;
                    _num_left_to_spawn--;
                }
            }
            spawn_y += 2.55f;
            spawn_x = -5.0f;
        }
    }

    void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        { 
            if (state == 0)
            {
                timeLeft += 4;
            }
            else if (state > 0 && state < 3)
            {
                directions2.GetComponent<Canvas>().sortingLayerName = "Text";

                if (state == 1) {

                    timeLeft += 20.0f;
                } else if (state == 2) {
                    timeLeft += breakBetweenWaves;
                }

                         
            } 
            else if(state == 3)
            {
                GlobalControl.Instance.totalDamage = int.Parse(GameObject.Find("DamageCounter").GetComponent<Text>().text);
                SceneManager.LoadScene("Question1");
            }
            state++;
            //Debug.Log("State change: " + state);
        }
        else if (state == 2) {
            float frequency = 0.0f;
            last_spawned += Time.deltaTime;
            frequency = 2.0f;

            if (last_spawned >= frequency) {
                if (_next_spawn == 0) {
                    SpawnPathogen(Pathogen.bouncing);
                    _next_spawn = 1;
                } else {
                    SpawnPathogen(Pathogen.linear);
                    _next_spawn = 0;
                }
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

    private void SpawnPathogen(Pathogen p) {
        if (p == Pathogen.linear) {
            Instantiate(linear_pathogen, Camera.main.ViewportToWorldPoint(new Vector3((float)random.NextDouble(), 1.05f, 2)), Quaternion.identity);
        } else if (p == Pathogen.bouncing) {
            Instantiate(bouncing_pathogen, Camera.main.ViewportToWorldPoint(new Vector3((float)random.NextDouble(), 1.05f, 2)), Quaternion.identity);
        }
    }
}