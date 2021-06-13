using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerOnSpawn : MonoBehaviourPun
{
    // Start is called before the first frame update
    void Start()
    {
        var isMine = photonView.IsMine;
        RandomizePlayerColor();
    }

    void RandomizePlayerColor()
    {
        if (photonView.IsMine)
        {
        this.GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        }
    }
}
