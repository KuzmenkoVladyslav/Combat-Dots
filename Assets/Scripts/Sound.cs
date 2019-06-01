using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sound
{
    public string audioName;

    public AudioClip audioClip;

    [Range(0f, 1f)]
    public float audioVolume;

    [Range(.1f, 3f)]
    public float audioPitch;

    [HideInInspector]
    public AudioSource audioSource;

}
