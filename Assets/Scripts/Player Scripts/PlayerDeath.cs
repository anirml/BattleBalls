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
            // TODO: FIX FOR MULTIPLAYER
            //PhotonNetwork.Destroy(this.gameObject);
            //PhotonNetwork.JoinRoom("QuickStartMenuDemo");
            //PhotonNetwork.JoinRoom("QuickStartMenuDemo");
            PhotonNetwork.Destroy(this.gameObject);
            //PhotonNetwork.Disconnect();
            //PhotonNetwork.Reconnect();
            //PhotonNetwork.Destroy(this.gameObject);
            //PhotonNetwork.ConnectUsingSettings();
            //PhotonNetwork.LeaveRoom(this.gameObject);
            Debug.Log("er vi her?");
            //PhotonNetwork.Disconnect();
            //RoomOptions roomOps = new RoomOptions() { IsVisible = true, IsOpen = true, MaxPlayers = (byte)20 };
            //PhotonNetwork.JoinOrCreateRoom("QuickStartMenuDemo",roomOps, null);		
            
        }

    }


    void OnDisconnected(){
        Debug.Log("Player Left Rooom");
        PhotonNetwork.ConnectUsingSettings();
    }
    void OnLeftRoom(){
        Debug.Log("Player Left Rooom");
    }

    void OnDestroy()
    {
        PlayerEvents.instance.PlayerDeath -= DestroyPlayer;
    }

}
