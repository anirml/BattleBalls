using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;


public class GameSetupController : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject player;
    void Start()
    {
        CreatePlayer();
    }

    private void CreatePlayer()
    {
        // We can use same script for spawning food randomly for the players too.
        Vector3 center = FoodManager.Instance.center;
        Vector3 size = FoodManager.Instance.size;
        //Debug.Log("Creating Player");
        // Randomizing and checking player spawn point on map
        Vector3 pos = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), Random.Range(1, 1), Random.Range(-size.z / 2, size.z / 2));
        Vector3 offset = new Vector3(0,15,0);
        bool objColliders = Physics.Raycast(pos + offset, Vector3.down, 15f);

        if (!objColliders)
        {
            PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PhotonPlayer"), pos, Quaternion.identity);
            // Debug.Log("Spawn check passed!");
        }
        else
        {
            // Debug.Log("Spawn check did not pass, rechecking..");
            CreatePlayer();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
