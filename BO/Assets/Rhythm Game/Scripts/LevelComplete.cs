using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour
{
    public AudioSource audio;
    public Animator animator;
    public TMPro.TextMeshPro score;
    public TMPro.TextMeshPro misses;
    public TMPro.TextMeshPro scoreText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!audio.isPlaying && audio.time == 0)
        {
            animator.SetTrigger("Completed");
            misses.text = "Misses: " + animator.GetInteger("Misses");
            score.text = scoreText.text;
        }

        if(!audio.isPlaying && Input.GetKeyDown(KeyCode.Return)){
            SceneManager.LoadScene(1);
        }
    }
}
