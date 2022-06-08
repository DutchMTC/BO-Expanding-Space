using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSwitcher : MonoBehaviour
{
    Animator animator;
    public Animator bgAnimator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        int index = animator.GetInteger("CharIndex");
        int bgIndex = bgAnimator.GetInteger("BGIndex");
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            animator.SetInteger("CharIndex", index + 1);
            bgAnimator.SetInteger("BGIndex", bgIndex + 1);
        }else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            animator.SetInteger("CharIndex", index - 1);
            bgAnimator.SetInteger("BGIndex", bgIndex - 1);
        }

        if (index < 0)
        {
            animator.SetInteger("CharIndex", 0);
        }
        else if(index > 3)
        {
            animator.SetInteger("CharIndex", 3);
        }

        if(bgIndex < 0)
        {
            bgAnimator.SetInteger("BGIndex", 0);
        }else if(bgIndex > 3)
        {
            bgAnimator.SetInteger("BGIndex", 3);
        }
    }
}
