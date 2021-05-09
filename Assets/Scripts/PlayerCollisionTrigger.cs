using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionTrigger : MonoBehaviour
{

    private float otherPlayerVelocity;
    private int otherPlayerId;
    private float ownSpeed;
    private float ownScale;

    void FixedUpdate()
    {
        ownSpeed = GetComponent<Rigidbody>().velocity.magnitude;
    }

    private void OnCollisionEnter(Collision other)
    {

        //Debug.Log("OnTriggerEnter in PlayerCollisionTrigger");
        if (other.gameObject.name == "Player")
        {
            Debug.Log("Hit other Player!");

            //otherPlayerVelocity = other.gameObject.GetComponent<Rigidbody>().velocity.magnitude;
            otherPlayerId = other.gameObject.GetInstanceID();

            Vector3 direction = other.contacts[0].point - transform.position;
            direction = -direction.normalized;

            // Alternatively make an "if" with a minimum velocity?
            OnPlayerCollisionTrigger(otherPlayerId, ownSpeed, direction, transform);
        }
    }


    void OnPlayerCollisionTrigger(int otherId, float ownVelocity, Vector3 collisionDirection, Transform ownTransform)
    {
        Debug.Log("OnPlayerCollisionTrigger in PlayerCollisionTrigger - Player id: " + otherId);

        PlayerEvents.instance.OnPlayerCollision(otherId, ownVelocity, collisionDirection, ownTransform);
    }







    // Not in use: depricated
    void ApplyPushback(Collision listenerCollision)
    {
        // Calculate angle between the collision point and the player, then normalizes the opposite Vector3
        Vector3 direction = listenerCollision.contacts[0].point - transform.position;
        direction = -direction.normalized;

        Debug.Log("ApplyPushback direction: " + direction);

        GetComponent<Rigidbody>().AddForce(direction*500);
        // Adds vertical force
        GetComponent<Rigidbody>().AddForce(new Vector3(0,1,0)*300);
    }
}
