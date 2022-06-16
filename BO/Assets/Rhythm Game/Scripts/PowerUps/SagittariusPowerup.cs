using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SagittariusPowerup : MonoBehaviour
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
        if ((Input.GetKeyDown(KeyCode.RightShift) || Input.GetKeyDown(KeyCode.LeftShift)) && canUse == true)
        {
            audioAnim.SetTrigger("PowerUpSagittarius");
            self.SetTrigger("SagittariusText");
            main.SetInteger("Misses", 0);            
            canUse = false;
        }
    }
}
