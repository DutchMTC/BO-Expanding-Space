using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1Explanation : MonoBehaviour
{
    public Animator self;
#pragma warning disable CS0108 // Member hides inherited member; missing new keyword
    public Animator audio;
#pragma warning restore CS0108 // Member hides inherited member; missing new keyword

    // Start is called before the first frame update
    void Start()
    {
        audio.SetTrigger("MusicOff");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            self.SetTrigger("Next");
        }

    }

    public void exit()
    {
        audio.SetTrigger("MusicOn");
    }
}
