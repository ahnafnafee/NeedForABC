using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetTimer : MonoBehaviour {

    Text text;
    float theTime = 0f;
    public float speed = 1;
    public bool playing;
    public GameObject PauseMenuUI;

    // Use this for initialization
    void Start () {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update () {
        if (playing)
        {
            theTime += Time.deltaTime * speed;
            string minutes = Mathf.Floor((theTime % 3600) / 60).ToString("00");
            string seconds = (theTime % 60).ToString("00");
            text.text = minutes + ":" + seconds;
        }
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!playing)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public float GetSec()
    {
        return theTime;
    }
    
    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        ClickPlay();
    }

    private void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        ClickStop();
    }

    public void ClickPlay ()
    {
        playing = true;
    }

    public void ClickStop()
    {
        playing = false;
    }

    public bool GetStatus()
    {
        return playing;
    }
}
