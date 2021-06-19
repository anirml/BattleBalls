using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;
using System.IO;

public class PlayerDeath : MonoBehaviourPun
{
    private Scene lobbyScene;
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
            // Debug.Log("Player Death ID: " + ownId);
            if (photonView.IsMine)
            {
                PlayerEvents.instance.PlayerDeath -= DestroyPlayer;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.Confined;
                SceneManager.LoadScene("QuickStartMenuDemo");
                PhotonNetwork.Disconnect();
            }
        }
    }

    private void OnDestroy()
    {
        // Debug.Log("Player Death ID: " + this.gameObject.GetInstanceID());
        // Instantiating splatter prefab on player's x and z position.
        Vector3 playerPos = this.gameObject.transform.localPosition;
        float playerScale = transform.localScale.x*1.25f;
        playerPos.y = 0.01f;
        Color32 color = GetComponent<PlayerOnSpawn>().finalColor;
        
        GameObject splat = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "Splatter"), playerPos, Quaternion.identity);
        
        splat.GetComponent<Splatter>().splatColor = color;
        splat.transform.localScale = new Vector3(playerScale, playerScale, playerScale);
        
        PlayerEvents.instance.PlayerDeath -= DestroyPlayer;
    }

    /*void OnDisconnectedFromPhoton()
    {
        Debug.Log("Player Left Room");
        PlayerEvents.instance.PlayerDeath -= DestroyPlayer;
    }
    void OnLeftRoom()
    {
        Debug.Log("Player Left Room");
        PlayerEvents.instance.PlayerDeath -= DestroyPlayer;
    }*/
}
