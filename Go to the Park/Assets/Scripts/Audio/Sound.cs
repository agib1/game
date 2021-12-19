using UnityEngine;
using UnityEngine.Audio;

//Sound class for audio manager
[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;

    [Range(0f,1f)]
    public float volume;

    public bool loop;

    [HideInInspector]
    public AudioSource source;
}
