using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionSounds : MonoBehaviour
{
    public List<AudioClip> audioClips;
    public AudioSource source;

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }

    public void PlayRandomCollisionSound()
    {
        source.PlayOneShot(audioClips[Random.Range(0, audioClips.Count)]);
    }
}
