using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CellGrid_Test : MonoBehaviour
{

    private int _columns;
    private int _rows;
    public int numCells;
    private int _num_left_to_spawn;
    public GameObject player;

    private GameObject[,] cells;

    void Awake() {
        _num_left_to_spawn = numCells;
        if (numCells >= 8) {
            _columns = 8;
        } else {
            _columns = numCells;
        }
        _rows = (int) Math.Ceiling(numCells / 8.0);
        cells = new GameObject[_rows, _columns];
    }

    // Start is called before the first frame update
    void Start() {
        float spawn_x = -3.0f;
        float spawn_y = -8.0f;
        for(int i = 0; i < _rows; i++) {
            for(int j = 0; j < _columns; j++) {
                //Debug.Log(i + ", " + j);
                if (_num_left_to_spawn > 0) {
                    cells[i,j] = Instantiate(player, new Vector3(spawn_x, spawn_y, 0), Quaternion.identity);
                    spawn_x += 2.55f;
                    _num_left_to_spawn--;
                }
            }
            spawn_y += 2.55f;
            spawn_x = -3.0f;
        }
    }

    // Update is called once per frame
    void Update() {
        
    }
}
