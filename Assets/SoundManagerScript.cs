using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour {

    private AudioSource audioOrigin;
    private int musicVolume = 1;


	// Use this for initialization
	void Start () {
        audioOrigin = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        //audioOrigin.volume = musicVolume;
	}

    public void SetVolume(int vol)
    {
        musicVolume = vol;        
    }
}
