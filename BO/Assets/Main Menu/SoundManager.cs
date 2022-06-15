using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField] Slider MusicSlider;

    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 1);
            load();
        }

        else
        {
            load();
        }
    }
    public void ChangeVolume()
    {
        AudioListener.volume = MusicSlider.value;
        save();
    }

    private void load()
    {
        MusicSlider.value = PlayerPrefs.GetFloat("musicVolume");
    }
    private void save()
    {
        PlayerPrefs.SetFloat("musicVolume", MusicSlider.value);
    }

}
