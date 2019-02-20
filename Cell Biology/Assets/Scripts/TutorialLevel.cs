using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;

public class TutorialLevel : MonoBehaviour
{
    public float timeLeft = 15.0f;
    public Text countdown;
    public GameObject player;
    public GameObject pathogen;
    public string[] messages = new string[] { "Welcome to Cell Biology", "Move w WASD / Arrow Keys", "These are pathogens, avoid them" };
    public int currMessage = 0;

    private void Start()
    {
        countdown.alignment = TextAnchor.UpperLeft;

    }

    void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {
            //if messages left?, then
            //display next popup message (messages[currMessage+1]
            //reset countdown
            //currM++
            //else, end level
            if (currMessage == 0)
            {
                var player_inst = Instantiate(player, new Vector3(0, 0, 0), Quaternion.identity);
                timeLeft += 10;
            }
            else if(currMessage == 1)
            {
                var path_inst = Instantiate(pathogen, new Vector3(0, 0, 0), Quaternion.identity);
                timeLeft += 15;
            }
            currMessage++;
        }
        else
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

        countdown.text = "Time left: " + minutes.ToString("00") + ":" + seconds.ToString("00");
    }
}