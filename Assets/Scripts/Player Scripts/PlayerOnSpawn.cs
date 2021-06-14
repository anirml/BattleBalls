using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerOnSpawn : MonoBehaviourPun
{
    private Color ballColor;

    // Start is called before the first frame update
    void Start()
    {
        // var isMine = photonView.IsMine;
        ballColor = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        // RandomizePlayerColor();
        GetComponent<PhotonView>().RPC("RandomizePlayerColor", RpcTarget.AllBuffered, ballColor);
    }

    [PunRPC]
    void RandomizePlayerColor(Color color)
    {
        // if (photonView.IsMine)
        // {
            this.GetComponent<Renderer>().material.color = color;
        // }
    }
}
