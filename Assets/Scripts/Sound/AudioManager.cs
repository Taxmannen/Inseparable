using UnityEngine;
using System;

/* Script made by Michael */
public class AudioManager : MonoBehaviour {
    public Sound[] sounds;
    static Sound[] finalSounds;

    void Awake()
    {
        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = false;
            s.source.playOnAwake = false;
        }
        finalSounds = sounds;
    }

    public static void Play(string name)
    {
        Sound s = Array.Find(finalSounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogError("Could not find" + " " + name);
            return;
        }
        s.source.Play();
    }
}
