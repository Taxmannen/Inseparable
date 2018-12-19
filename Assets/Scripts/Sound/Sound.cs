using UnityEngine;
using System;

/* Script made by Michael */
[Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;
    [Range(0f, 1f)]
    public float volume = 1;
    [Range(-3f, 3f)]
    public float pitch = 1;
    [HideInInspector]
    public AudioSource source;
}
