using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionTrigger : MonoBehaviour
{

    private float otherPlayerVelocity;
    private int otherPlayerId;
    private float ownSpeed;
    private Vector3 ownVelocity;
    private Transform ownTransform;

    void FixedUpdate()
    {
        ownSpeed = GetComponent<Rigidbody>().velocity.magnitude;
        ownVelocity = GetComponent<Rigidbody>().velocity;
        ownTransform = transform;

    }

    private void OnCollisionEnter(Collision other)
    {

        //Debug.Log("OnTriggerEnter in PlayerCollisionTrigger");
        if (other.gameObject.tag == "Player")
        {
            // Debug.Log("Hit other Player!");

            //otherPlayerVelocity = other.gameObject.GetComponent<Rigidbody>().velocity.magnitude;
            otherPlayerId = other.gameObject.GetInstanceID();

            Vector3 direction = other.contacts[0].point - ownTransform.position;
            int ownId = this.gameObject.GetInstanceID();
            //direction = -direction.normalized;

            // Alternatively make an "if" with a minimum velocity?
            OnPlayerCollisionTrigger(otherPlayerId, ownId, ownSpeed, direction, ownTransform, ownVelocity);
        }
    }


    void OnPlayerCollisionTrigger(int otherId, int ownId, float ownSpeed, Vector3 collisionDirection, Transform ownTransform, Vector3 ownVelocity)
    {
        //Debug.Log("OnPlayerCollisionTrigger in PlayerCollisionTrigger - Player id: " + otherId);

        PlayerEvents.instance.OnPlayerCollision(otherId, ownId, ownSpeed, collisionDirection, ownTransform, ownVelocity);
    }







    // Not in use: depricated
    void ApplyPushback(Collision listenerCollision)
    {
        // Calculate angle between the collision point and the player, then normalizes the opposite Vector3
        Vector3 direction = listenerCollision.contacts[0].point - transform.position;
        direction = -direction.normalized;

        // Debug.Log("ApplyPushback direction: " + direction);

        GetComponent<Rigidbody>().AddForce(direction*500);
        // Adds vertical force
        GetComponent<Rigidbody>().AddForce(new Vector3(0,1,0)*300);
    }
}