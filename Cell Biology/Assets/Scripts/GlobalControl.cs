using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalControl : MonoBehaviour
{
    public int totalDamage;
    public int cellGroupSize;
    public int Q1Score;
    public int Q2Score;
    public int Q3Score;
    public int Q4Score;
    public int Q5Score;
    public int max = 24;

    public static GlobalControl Instance;

    void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }
    public int ComputeNumCells(int score)
    {
        if (cellGroupSize == max)
        {
            return 0;
        }
        int dif = max - cellGroupSize;
        int addedCells = (int)(dif * score) / 30;
        cellGroupSize += addedCells;
        return addedCells;
    }
}
