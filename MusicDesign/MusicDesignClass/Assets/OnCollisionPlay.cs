using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollisionPlay : MonoBehaviour {

    private AudioSource sheepSource;

    [Range (0.0f,1.0f)]
    public float f_vol;

    [Range(0.0f, 1.0f)]
    public float f_pitch;

    private void OnTriggerEnter(Collider other)
    {
        float fVolRand = Random.Range(0.0f, f_vol);
        sheepSource.volume = Random.Range(0.0f, f_vol);
        sheepSource.pitch = Random.Range(0.0f, f_pitch);
        sheepSource.Play();
    }

    // Use this for initialization
    void Start () {
        sheepSource = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
