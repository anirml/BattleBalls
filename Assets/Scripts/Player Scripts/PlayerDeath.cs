using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PlayerDeath : MonoBehaviourPun
{
    // Start is called before the first frame update
    void Start()
    {
        // calls Event from singleton (subscribe)
        PlayerEvents.instance.PlayerDeath += DestroyPlayer;
    }

    void DestroyPlayer(int ownId)
    {
        if (this.gameObject.GetInstanceID() == ownId)
        {
            Debug.Log(ownId);
            //PhotonNetwork.Disconnect();
            PhotonNetwork.LoadLevel(0);	       
        }

    }


   /* void OnPhotonPlayerDisconnected(){
        Debug.Log("Player Left Rooom");
        PhotonNetwork.Reconnect();
        //PhotonNetwork.LoadLevel(0);
        //PhotonNetwork.ConnectUsingSettings();
    } */
    void OnLeftRoom(){
        Debug.Log("Player Left Rooom");
    }

    void OnDestroy()
    {
        PlayerEvents.instance.PlayerDeath -= DestroyPlayer;
    }

}
