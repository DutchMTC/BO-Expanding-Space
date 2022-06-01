using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator animator;

    public void Fade()
    {
        animator.SetTrigger("Fade Out");
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
}
