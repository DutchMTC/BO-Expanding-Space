using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapricornPowerup : MonoBehaviour
{
    public Animator audioAnim;
    public Animator self;
    public Animator main;
    bool canUse = true;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightShift) && canUse == true)
        {
            audioAnim.SetTrigger("PowerUpCapricorn");
            self.SetTrigger("UsePowerUp");
            main.SetInteger("Misses", main.GetInteger("Misses") - 5);            
            canUse = false;
        }
    }
}
