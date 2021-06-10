using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerDeath : MonoBehaviourPun
{
    // Start is called before the first frame update
    void Start()
    {
        // calls Event from singleton (subscribe)
        PlayerEvents.instance.PlayerDeath += DestroyPlayer;
    }

    void DestroyPlayer()
    {
        Debug.Log("LOOK HERE YOU SILLY GEESE-------------");
        // TODO: FIX FOR MULTIPLAYER
        //PhotonNetwork.Destroy(this.gameObject);
        //PhotonNetwork.JoinRoom("QuickStartMenuDemo");
        Object.Destroy(this.gameObject);
    }

    void OnDestroy()
    {
        PlayerEvents.instance.PlayerDeath -= DestroyPlayer;
    }

}
