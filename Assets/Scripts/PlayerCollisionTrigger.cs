using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionTrigger : MonoBehaviour
{

    private float otherPlayerVelocity;
    private int otherPlayerId;
    private float ownSpeed;
    private float ownScale;

    void Start()
    {
        ownScale = this.transform.localScale.x;
    }

    void FixedUpdate()
    {
        ownSpeed = this.gameObject.GetComponent<Rigidbody>().velocity.magnitude;
    }

    private void OnCollisionEnter(Collision other)
    {

        Debug.Log("OnTriggerEnter in PlayerCollisionTrigger");
        if (other.gameObject.name == "Player")
        {
            Debug.Log("Hit other Player!");

            //otherPlayerVelocity = other.gameObject.GetComponent<Rigidbody>().velocity.magnitude;
            otherPlayerId = other.gameObject.GetInstanceID();

            // alternatively make an "if" with a minimum velocity?
            OnPlayerCollisionTrigger(otherPlayerId, ownSpeed, ownScale);
        }
    }

    void OnPlayerCollisionTrigger(int otherId, float ownVelocity, float ownScale)
    {
        Debug.Log("OnPlayerCollisionTrigger in PlayerCollisionTrigger - Player id: " + otherId);

        PlayerEvents.instance.OnPlayerCollision(otherId, ownVelocity, ownScale);
    }
}
