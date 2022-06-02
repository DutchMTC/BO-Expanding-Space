using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    public Boolean pause;
    public AudioSource audioSource;
    public Animator pauseAnimator;
    public Animator pauseTextAnimator;
    public GameObject pauseScreen;
    public GameObject allLanes;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pause == true)
            {
                pause = false;
                pauseAnimator.SetTrigger("PitchUp");
            }
            else if (pause == false)
            {
                pause = true;
                pauseAnimator.SetTrigger("PitchDown");
            }
        }
    }

    internal void pauseGame()
    {
        allLanes.SetActive(false);
        audioSource.Pause();
    }

    internal void continueGame()
    {
        allLanes.SetActive(true);
        audioSource.UnPause();
    }

    internal void pauseTrigger()
    {
        pauseTextAnimator.SetTrigger("Pause");
    }

    internal void unpauseTrigger()
    {
        pauseTextAnimator.SetTrigger("Unpause");
    }
}
