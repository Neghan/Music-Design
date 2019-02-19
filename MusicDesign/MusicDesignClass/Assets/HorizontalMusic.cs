using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalMusic : MonoBehaviour {
    public AudioSource[] sourceArray = new AudioSource[4];

    public AudioSource idleMusic;
    public AudioSource combatMusic;
    public AudioSource transitionStinger;

    public float fadeInSpeed;
    public float fadeOutSpeed;


    // Use this for initialization
    void Start () {
        sourceArray = GetComponents<AudioSource>();
        idleMusic = sourceArray[1];
        combatMusic = sourceArray[2];
        transitionStinger = sourceArray[3];

        fadeInSpeed = 0.01f;
        fadeOutSpeed = 0.05f;
        idleMusic.volume = 1.0f;
        combatMusic.volume = 0.0f;
    }

    static IEnumerator FadeOut(float fadeOutSpeed, AudioSource idleMusic)
    {
        while (idleMusic.volume > 0.01f)
        {
            idleMusic.volume -= fadeOutSpeed;
            yield return new WaitForSeconds(0.1f);
        }
    }

    static IEnumerator FadeIn(float fadeInSpeed, AudioSource combatMusic)
    {
        combatMusic.volume = 0.0f;
        while (combatMusic.volume < 1.0f)
        {
            combatMusic.volume += fadeInSpeed;
            yield return new WaitForSeconds(0.1f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Combat"))
        {
            transitionStinger.Play();
            StartCoroutine(FadeOut(fadeOutSpeed, idleMusic));
            StartCoroutine(FadeIn(fadeInSpeed, combatMusic));
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
