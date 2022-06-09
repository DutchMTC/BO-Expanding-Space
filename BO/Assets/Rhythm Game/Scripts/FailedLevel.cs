using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FailedLevel : MonoBehaviour
{
    public Animator animator;
    public Animator mainAnimator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(mainAnimator.GetInteger("Misses") >= 20 && (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Escape) || Input.GetMouseButtonDown(0)))
        {
            SceneManager.LoadScene(1);
        }
    }

    public void levelFailed()
    {
        animator.SetTrigger("PitchDown");
    }
}
