using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionListener : MonoBehaviour
{
    private int listenerId;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start in PlayerCollisionListener");
        listenerId = this.gameObject.GetInstanceID();
        PlayerSizeEvents.instance.PlayerCollision += ChangeSize;
    }

    void ChangeSize(int triggerId)
    {
        Debug.Log("ChangeSize in CollisionListener - Listener id: " + listenerId + " - Trigger id: " + triggerId);
        if(triggerId == listenerId)
        {
            Debug.Log("It's working for " + triggerId + "!");
        }
    }
}
