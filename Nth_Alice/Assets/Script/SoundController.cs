using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    static AudioSource audioSource;
    public static AudioClip audioClip;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioClip = Resources.Load<AudioClip>("Collision");
    }

    public static void SoundPlay()
    {
        audioSource.PlayOneShot(audioClip);
    }
}
