using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionListener : MonoBehaviour
{
    private int listenerId;
    private float currentSize;
    private float listenerVelocity;
    private float relativeVelocity = 0.2f;
    private Vector3 scaleIncrease;

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("Start in PlayerCollisionListener");
        currentSize = this.gameObject.transform.localScale.x;
        listenerVelocity = this.gameObject.GetComponent<Rigidbody>().velocity.magnitude;
        listenerId = this.gameObject.GetInstanceID();

        // calls Event from singleton
        PlayerSizeEvents.instance.PlayerCollision += ChangeSize;
    }

    void ChangeSize(int triggerId, float triggerVelocity)
    {
        //Debug.Log("ChangeSize in CollisionListener - Listener id: " + listenerId + " - Trigger id: " + triggerId);

        // Makes sure only relevant objects reacts to the invoke by checking ids
        if(triggerId == listenerId)
        {
            Debug.Log("TriggerVelocity for id: - " + triggerId + " = " + triggerVelocity);
            Debug.Log("ListenerVelocity for id: - " + listenerId + " = " + listenerVelocity);

            // Probably needs a guard to make sure the value is usable; can be negative
            //relativeVelocity = (listenerVelocity - triggerVelocity)/10; // doesn't work, they can be negative for both trigger and listener
            
            scaleIncrease = new Vector3(relativeVelocity, relativeVelocity, relativeVelocity); // temp value

            this.gameObject.transform.localScale += scaleIncrease;
        }
    }

    // add force based on the normalized relative positions
}
