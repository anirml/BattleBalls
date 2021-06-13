using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioSource source;
    
    // Singleton
    public static MusicManager Instance
    {
        get
        {
            if (instance == null)
                instance = FindObjectOfType(typeof(MusicManager)) as MusicManager;

            return instance;
        }
        set
        {
            instance = value;
        }
    }

    private static MusicManager instance;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    public void PauseBackgroundMusic()
    {
        source.Pause();
    }

    public void PlayBackgroundMusic()
    {
        source.Play();
    }
}
