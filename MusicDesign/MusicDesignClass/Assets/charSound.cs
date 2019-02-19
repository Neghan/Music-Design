using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class FootStepGroup
{
    public List<AudioClip> audioClips;
}

public class charSound : MonoBehaviour {

    private AudioSource audioComponent;
    private FootStepGroup footstepGroup;

    public List<FootStepGroup> footsteps;

    private int i_surface;
    private string s_surfaceString;


    public float f_volMin = 0.1f;
    public float f_volMax = 0.8f;

    public float f_pitchMin = 0.5f;
    public float f_pitchMax = 0.8f;

    // Use this for initialization
    void Start () {
        audioComponent = GetComponent<AudioSource>();
        footstepGroup = footsteps[0];
	}

    void Footstep_left()
    {
        audioComponent.pitch = Random.Range(f_pitchMin, f_pitchMax);
        audioComponent.volume = Random.Range(f_volMin, f_volMax);
        audioComponent.clip = footstepGroup.audioClips[Random.Range(0, footstepGroup.audioClips.Count)];
        audioComponent.Play();
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(s_surfaceString != hit.transform.tag)
        {
            switch (hit.transform.tag)
            {
                case "Grass":
                    i_surface = 0;
                    break;
                case "Soil":
                    i_surface = 1;
                    break;
                default:
                    i_surface = 0;
                    break;
            }
            s_surfaceString = hit.transform.tag;
            footstepGroup = footsteps[i_surface];
        }
    }

    void Footstep_right()
    {
        audioComponent.pitch = Random.Range(f_pitchMin, f_pitchMax);
        audioComponent.volume = Random.Range(f_volMin, f_volMax);
        audioComponent.clip = footstepGroup.audioClips[Random.Range(0, footstepGroup.audioClips.Count)];
        audioComponent.Play();
    }


    // Update is called once per frame
    void Update () {
		
	}
}
