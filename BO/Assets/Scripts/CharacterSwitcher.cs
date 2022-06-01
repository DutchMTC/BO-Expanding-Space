using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSwitcher : MonoBehaviour
{
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        int index = animator.GetInteger("CharIndex");
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            animator.SetInteger("CharIndex", index+1);
        }else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            animator.SetInteger("CharIndex", index-1);
        }

        if (index < 0)
        {
            animator.SetInteger("CharIndex", 0);
        }
        else if(index > 1)
        {
            animator.SetInteger("CharIndex", 1);
        }
    }
}
