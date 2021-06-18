using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionSounds : MonoBehaviour
{
    public List<AudioClip> audioClips;
    public AudioClip foodClip;
    public AudioClip bounceClip;
    public AudioSource source;

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }

    public void PlayRandomCollisionSound()
    {
        source.PlayOneShot(audioClips[Random.Range(0, audioClips.Count)]);
    }

    public void PlayPickUpFoodSound()
    {
        source.PlayOneShot(foodClip);
    }

    public void PlayBounceSound(float volume)
    {
        source.PlayOneShot(bounceClip, Random.Range(0.05f, 0.15f));
    }
}
