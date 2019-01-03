using UnityEngine;
using System;
using UnityEngine.Audio;

/* Script made by Michael */
public class AudioManager : MonoBehaviour {
    public AudioMixerGroup mixer;
    public Sound[] sounds;
    static Sound[] finalSounds;

    void Awake()
    {
        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.outputAudioMixerGroup = mixer;
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

    public static void Stop(string name)
    {
        Sound s = Array.Find(finalSounds, sound => sound.name == name);
        if(s == null)
        {
            Debug.LogError("Could not find" + " " + name);
            return;
        }
        s.source.Stop();
    }

    public static void PlayOneShot(string name)
    {
        Sound s = Array.Find(finalSounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogError("Could not find" + " " + name);
            return;
        }
        s.source.PlayOneShot(s.source.clip);
    }
}
