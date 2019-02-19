using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class DyingSound : MonoBehaviour {

    private GameObject playerObj;
    private AudioLowPassFilter lpf;
    public AudioMixer mainMixer;


	// Use this for initialization
	void Start () {
        playerObj = GameObject.FindGameObjectWithTag("Player");
        lpf = GetComponent<AudioLowPassFilter>();
	}
	
	// Update is called once per frame
	void Update () {
        if (playerObj.GetComponent<VerticalMusic>().PlayerLife<=30)
        {
            lpf.cutoffFrequency = 500.0f;
            mainMixer.SetFloat("dialogVolume", -30.0f);
        }
	}
}
