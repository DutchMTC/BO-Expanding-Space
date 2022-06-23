using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundTriggerReset : MonoBehaviour
{
    public Animator main;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetBGTrigger()
    {
        main.ResetTrigger("HitBG");
        main.ResetTrigger("HitBGMiss");
        main.ResetTrigger("HitBGPerfect");
    }
}
