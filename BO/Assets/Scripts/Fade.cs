using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fade : MonoBehaviour     
{
    public Scene nextLevel;
    public GameObject objectToFade;
    public Animator animator;
    public Animator getLevelAnimator;
    public AudioSource sfx;
    // Start is called before the first frame update
    public void NextLevel()
    {
        animator.SetTrigger("Fade Out");
    }

    public void onFadeComplete()
    {
        int index = getLevelAnimator.GetInteger("CharIndex");
        SceneManager.LoadScene(index + 2);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Return) || Input.GetKey(KeyCode.Space))
        {
            NextLevel();
            sfx.Play();
        }
    }

}
