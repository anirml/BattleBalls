using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionTrigger : MonoBehaviour
{
    private void OnCollisionEnter(Collision other) {
        
        Debug.Log("OnTriggerEnter in PlayerCollisionTrigger");
        if (other.gameObject.name == "Player")
        {
            Debug.Log("Hit other Player!");
            OnPlayerCollisionTrigger(other.gameObject.GetInstanceID(), other.gameObject.GetComponent<Rigidbody>().velocity.magnitude);
        }
    }

    void OnPlayerCollisionTrigger(int otherId, float velocity) {
        {
            Debug.Log("OnPlayerCollisionTrigger in PlayerCollisionTrigger - id: " + otherId);
            PlayerSizeEvents.instance.OnPlayerCollision(otherId, velocity);
        }
    }
}
