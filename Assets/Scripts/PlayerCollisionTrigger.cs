using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionTrigger : MonoBehaviour
{

    private float otherPlayerVelocity;
    private int otherPlayerId;

    private void OnCollisionEnter(Collision other)
    {

        Debug.Log("OnTriggerEnter in PlayerCollisionTrigger");
        if (other.gameObject.name == "Player")
        {
            Debug.Log("Hit other Player!");

            otherPlayerVelocity = other.gameObject.GetComponent<Rigidbody>().velocity.magnitude;
            otherPlayerId = other.gameObject.GetInstanceID();

            // alternatively make an "if" with a minimum velocity?
            OnPlayerCollisionTrigger(otherPlayerId, otherPlayerVelocity);
        }
    }

    void OnPlayerCollisionTrigger(int otherId, float velocity)
    {
        Debug.Log("OnPlayerCollisionTrigger in PlayerCollisionTrigger - Player id: " + otherId);

        PlayerSizeEvents.instance.OnPlayerCollision(otherId, velocity);
    }
}
