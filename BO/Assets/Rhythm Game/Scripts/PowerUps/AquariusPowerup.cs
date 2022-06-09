using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AquariusPowerup : MonoBehaviour
{
    public Animator audioAnim;
    public Animator self;
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
            audioAnim.SetTrigger("PowerUpAquarius");
            self.SetTrigger("UsePowerUp");
            canUse = false;
        }
    }
}
