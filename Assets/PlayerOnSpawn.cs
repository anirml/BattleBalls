using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOnSpawn : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        RandomizePlayerColor();
    }

    void RandomizePlayerColor()
    {
        this.GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
    }
}
