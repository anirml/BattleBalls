using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PlayerOnSpawn : MonoBehaviourPun
{
    private bool hasChanged = false;
    private float[] values = new float[3];

    [HideInInspector]
    public int playerId;
    [HideInInspector]
    public Color playerColor;
    public Color finalColor = Color.clear;

    // Start is called before the first frame update
    void Start()
    {
        values[0] = Random.Range(0f, 1f);
        values[1] = Random.Range(0f, 1f);
        values[2] = Random.Range(0f, 1f);

        playerId = this.gameObject.GetInstanceID();
        GetComponent<PhotonView>().RPC("RandomizePlayerColor", RpcTarget.AllBuffered, values);
    }

    [PunRPC]
    void RandomizePlayerColor(float[] colorValues)
    {
        finalColor[0] = colorValues[0];
        finalColor[1] = colorValues[1];
        finalColor[2] = colorValues[2];
        finalColor[3] = 1f;

        if (!hasChanged)
        {
            this.GetComponent<Renderer>().material.color = finalColor;
            playerColor = finalColor;
            hasChanged = true;
        }

    }
}
