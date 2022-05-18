using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel2 : MonoBehaviour     
{
    public Scene nextLevel;
    public GameObject objectToFade;
    public Animator animator;
    // Start is called before the first frame update
    public void NextLevel()
    {
        animator.SetTrigger("Fade Out");
    }

    public void onFadeComplete()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
