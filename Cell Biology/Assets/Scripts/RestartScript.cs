using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartScript : MonoBehaviour
{
    public void OnMouseButton()
    {
        SceneManager.LoadScene("Video");
    }

    public void ToTutorial()
    {
        SceneManager.LoadScene("TutorialLevel");
    }

    public void ToLevel1()
    {
        SceneManager.LoadScene("Level1");
    }
}
