using Melanchall.DryWetMidi.Interaction;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lane : MonoBehaviour
{
    public Melanchall.DryWetMidi.MusicTheory.NoteName noteRestriction;
    public KeyCode input;
    public KeyCode secondaryInput;
    public GameObject notePrefab;
    List<Note> notes = new List<Note>();
    public List<double> timeStamps = new List<double>();
    public int misses;
    public Animator audioAnimator;
    public Animator failAnimator;
    public GameObject decentPrefab;
    public GameObject nicePrefab;
    public GameObject awesomePrefab;
    public GameObject perfectPrefab;
    public GameObject missPrefab;
    public GameObject accuracyParent;
    public ParticleSystem hitParticle;
    public GameObject particleParent;

    int spawnIndex = 0;
    int inputIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void SetTimeStamps(Melanchall.DryWetMidi.Interaction.Note[] array)
    {
        foreach (var note in array)
        {
            if (note.NoteName == noteRestriction)
            {
                var metricTimeSpan = TimeConverter.ConvertTo<MetricTimeSpan>(note.Time, SongManager.midiFile.GetTempoMap());
                timeStamps.Add((double)metricTimeSpan.Minutes * 60f + metricTimeSpan.Seconds + (double)metricTimeSpan.Milliseconds / 1000f);
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (spawnIndex < timeStamps.Count)
        {
            if (SongManager.GetAudioSourceTime() >= timeStamps[spawnIndex] - SongManager.Instance.noteTime)
            {
                var note = Instantiate(notePrefab, transform);
                notes.Add(note.GetComponent<Note>());
                note.GetComponent<Note>().assignedTime = (float)timeStamps[spawnIndex];
                spawnIndex++;
            }
        }

        if (inputIndex < timeStamps.Count)
        {
            double timeStamp = timeStamps[inputIndex];
            double marginOfError = SongManager.Instance.marginOfError;
            double audioTime = SongManager.GetAudioSourceTime() - (SongManager.Instance.inputDelayInMilliseconds / 2000.0);
            int misses = failAnimator.GetInteger("Misses");

            if (Input.GetKeyDown(input) || Input.GetKeyDown(secondaryInput))
            {
                if (Math.Abs(audioTime - timeStamp) < marginOfError)
                {
                    Hit();
                    print($"Hit on {inputIndex} note");
                    ParticleSystem hit = Instantiate(hitParticle, new Vector3(notes[inputIndex].transform.position.x, notes[inputIndex].transform.position.y, notes[inputIndex].transform.position.z), Quaternion.identity, particleParent.transform);
                    Destroy(hit, 1f);
                    Destroy(notes[inputIndex].gameObject);
                    inputIndex++;
                }
            
                else
                {
                    print($"Hit inaccurate on {inputIndex} note with {Math.Abs(audioTime - timeStamp)} delay");
                    failAnimator.SetInteger("Misses", misses + 1);
                }

                if (Math.Abs(audioTime - timeStamp) <= 0.12 && Math.Abs(audioTime - timeStamp) > 0.05)
                {
                    print("Decent!");
                    GameObject nice = Instantiate(decentPrefab, new Vector3(270.3f, transform.position.y, transform.position.z), Quaternion.identity, accuracyParent.transform);
                    Destroy(nice, 1f);
                    failAnimator.SetTrigger("HitBG");
                }
                else if (Math.Abs(audioTime - timeStamp) <= 0.05 && Math.Abs(audioTime - timeStamp) > 0.03)
                {
                    print("Nice!");
                    GameObject nice = Instantiate(nicePrefab, new Vector3(270.3f, transform.position.y, transform.position.z), Quaternion.identity, accuracyParent.transform);
                    Destroy(nice, 1f);
                    failAnimator.SetTrigger("HitBG");
                }
                else if (Math.Abs(audioTime - timeStamp) <= 0.03 && Math.Abs(audioTime - timeStamp) > 0.01)
                {
                    print("Awesome!");
                    GameObject nice = Instantiate(awesomePrefab, new Vector3(270.3f, transform.position.y, transform.position.z), Quaternion.identity, accuracyParent.transform);
                    Destroy(nice, 1f);
                    failAnimator.SetTrigger("HitBG");
                }
                else if (Math.Abs(audioTime - timeStamp) <= 0.01)
                {
                    Hit();
                    print("Perfect!");
                    GameObject nice = Instantiate(perfectPrefab, new Vector3(270.3f, transform.position.y, transform.position.z), Quaternion.identity, accuracyParent.transform);
                    Destroy(nice, 1f);
                    failAnimator.SetTrigger("HitBGPerfect");
                }
            }
            if (timeStamp + marginOfError <= audioTime)
            {
                Miss();
                GameObject nice = Instantiate(missPrefab, new Vector3(270.3f, transform.position.y, transform.position.z), Quaternion.identity, accuracyParent.transform);
                Destroy(nice, 1f);
                failAnimator.SetTrigger("HitBGMiss");
                failAnimator.SetInteger("Misses", misses + 1);
                Debug.Log(misses);
                print($"Missed {inputIndex} note");
                inputIndex++;
            }

            if (misses >= 20)
            {
                audioAnimator.SetTrigger("PitchDownFailed");
            }
        }
    }

    private void Hit()
    {
        ScoreManager.Hit();
    }
    private void Miss()
    {
        ScoreManager.Miss();
    }
}
