using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public Sound[] Sounds;

    void Awake()
    {
        foreach (Sound x in Sounds)
        {
            x.audioSource = gameObject.AddComponent<AudioSource>();
            x.audioSource.clip = x.audioClip;
            x.audioSource.volume = x.audioVolume;
            x.audioSource.pitch = x.audioPitch;
        }
    }

    public void Play(string soundName)
    {
        Sound x = Array.Find(Sounds, sound => sound.audioName == soundName);
        x.audioSource.Play();
    }
}
