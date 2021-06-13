using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class NetworkManager : MonoBehaviourPunCallbacks
{

    //public scene arena;
    // Start is called before the first frame update
    void Start()
    {
        Connect();
    }

    public void Connect()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public void Play()
    {
        //RoomOptions options = new RoomOptions() { MaxPlayers = 20 };
        //PhotonNetwork.CreateRoom("Flat", options, TypedLobby.Default);
          PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("Tried to join Arena, but failed!");
        PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = 20 });
        //PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Joined Arena!");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
