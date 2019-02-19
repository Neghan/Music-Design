using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class VerticalMusic : MonoBehaviour {

    public AudioMixerSnapshot startSnapshot;
    public AudioMixerSnapshot combatSnapshot;

    public float bpm;
    public float meter;

    private float quarterNoteLen;
    private float bar;
    private float transitionTime;

    public int PlayerLife;

    // Use this for initialization
    void Start () {
        quarterNoteLen = 60 / bpm;
        bar = quarterNoteLen * 4 * meter;
        transitionTime = bar;
        PlayerLife = 100;
	}

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Combat"))
        {
            
            startSnapshot.TransitionTo(0.5f);
            PlayerLife = 30;
        }
    }


    // Update is called once per frame
    void Update () {
		
	}
}
