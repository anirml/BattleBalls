using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeathSound : MonoBehaviour
{
    public AudioClip deathClip;
    public AudioSource source;
    
    private void Start()
    {
        source = GetComponent<AudioSource>();
    }

    public void PlayDeathSound()
    {
        source.PlayOneShot(deathClip);
    }
}
