using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerOnSpawn : MonoBehaviourPun
{
    private bool hasChanged = false;
    private float[] values = new float[3];

    // Start is called before the first frame update
    void Start()
    {
        values[0] = Random.Range(0f, 1f);
        values[1] = Random.Range(0f, 1f);
        values[2] = Random.Range(0f, 1f);

        GetComponent<PhotonView>().RPC("RandomizePlayerColor", RpcTarget.AllBuffered, values);
    }

    [PunRPC]
    void RandomizePlayerColor(float[] colorValues)
    {
        Color color = Color.clear;
        color[0] = colorValues[0];
        color[1] = colorValues[1];
        color[2] = colorValues[2];
        color[3] = 1f;

        if (!hasChanged)
        {
            this.GetComponent<Renderer>().material.color = color;
            hasChanged = true;
        }
    }
}
