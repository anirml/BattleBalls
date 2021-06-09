using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerDeath : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // calls Event from singleton (subscribe)
        PlayerEvents.instance.PlayerDeath += DestroyPlayer;
    }

    void DestroyPlayer()
    {
        // TODO: FIX FOR MULTIPLAYER
        // PhotonNetwork.Destroy();
        Object.Destroy(this);
    }

    void OnDestroy()
    {
        PlayerEvents.instance.PlayerDeath -= DestroyPlayer;
    }

}
