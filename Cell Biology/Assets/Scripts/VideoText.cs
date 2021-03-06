﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoText : MonoBehaviour
{
    public GameObject ccTitle;
    public GameObject ccText1;
    public GameObject ccText2;

    public GameObject envelopeSpindleTitle;
    public GameObject envelopeSpindleText1;

    public GameObject kinetochoreTitle;
    public GameObject kinetochoreText1;
    public GameObject kinetochoreText2;

    public GameObject spindleBipolarityTitle;
    public GameObject spindleBipolarityText1;
    public GameObject spindleBipolarityText2;

    public GameObject anaphaseTitle;
    public GameObject anaphaseText1;

    public GameObject cytokinesisTitle;
    public GameObject cytokinesisText1;
    public GameObject cytokinesisText2;
    public bool pause = false;
    public GameObject pauseView;
    public GameObject playView;



    float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        envelopeSpindleTitle.SetActive(false); // Hide all other text at start
        kinetochoreTitle.SetActive(false);
        spindleBipolarityTitle.SetActive(false);
        anaphaseTitle.SetActive(false);
        cytokinesisTitle.SetActive(false);

        ccText2.SetActive(false);
        envelopeSpindleText1.SetActive(false);
        kinetochoreText1.SetActive(false);
        kinetochoreText2.SetActive(false);
        spindleBipolarityText1.SetActive(false);
        spindleBipolarityText2.SetActive(false);
        anaphaseText1.SetActive(false);
        cytokinesisText1.SetActive(false);
        cytokinesisText2.SetActive(false);
        GameObject.Find("MitosisVideo").transform.GetComponent<VideoPlayer>().url = System.IO.Path.Combine(Application.streamingAssetsPath, "MitosisVid.mp4");

    }

    void Update()
    {
        if (!pause)
        {
            timer += Time.deltaTime;
        }

        if (timer >= 8f)
        {
            ccText1.SetActive(false);
            ccText2.SetActive(true);
        }
        if (timer >= 16f)
        {
            ccText2.SetActive(false);
            ccTitle.SetActive(false);
            envelopeSpindleTitle.SetActive(true);
            envelopeSpindleText1.SetActive(true);
        }
        if (timer >= 22f)
        {
           envelopeSpindleTitle.SetActive(false);
           envelopeSpindleText1.SetActive(false);
           kinetochoreTitle.SetActive(true);
           kinetochoreText1.SetActive(true);

        }
        if (timer >= 27f)
        {
            kinetochoreText1.SetActive(false);
            kinetochoreText2.SetActive(true);
        }
        if (timer >= 31f)
        {
            kinetochoreTitle.SetActive(false);
            kinetochoreText2.SetActive(false);
            spindleBipolarityTitle.SetActive(true);
            spindleBipolarityText1.SetActive(true);

        }
        if (timer >= 35f)
        {
            spindleBipolarityText1.SetActive(false);
            spindleBipolarityText2.SetActive(true);
        }
        if (timer >= 38f)
        {
            spindleBipolarityTitle.SetActive(false);
            spindleBipolarityText2.SetActive(false);
            anaphaseTitle.SetActive(true);
            anaphaseText1.SetActive(true);
        }
        if (timer >= 41f)
        {
            anaphaseTitle.SetActive(false);
            anaphaseText1.SetActive(false);
            cytokinesisTitle.SetActive(true);
            cytokinesisText1.SetActive(true);
        }
        if (timer >= 45)
        {
            cytokinesisText1.SetActive(false);
            cytokinesisText2.SetActive(true);
        }
        if (timer >= 55)
        {
            cytokinesisText2.SetActive(false);
            cytokinesisTitle.SetActive(false);
            GameObject p= GameObject.Find("Pause");
            p.GetComponent<Button>().interactable = false;
        }
    } 

    public void OnPause()
    {
        if (pause)
        {
            GameObject.Find("MitosisVideo").transform.GetComponent<VideoPlayer>().Play();
            pauseView.SetActive(true);
            playView.SetActive(false);
            pause = false;
        }
        else
        {
            GameObject.Find("MitosisVideo").transform.GetComponent<VideoPlayer>().Pause();
            pauseView.SetActive(false);
            playView.SetActive(true);
            pause = true;
        }
    }
}

  
