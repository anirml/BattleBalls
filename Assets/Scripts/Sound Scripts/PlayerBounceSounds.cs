using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBounceSounds : MonoBehaviour
{
    public bool isGrounded = false;
    public float verticalVelocity;

    void Update()
    {
        verticalVelocity = GetComponent<Rigidbody>().velocity.magnitude;
    }

    private void OnCollisionEnter(Collision other)
    {
        if ((other.gameObject.layer == 6 || other.gameObject.layer == 8) && !isGrounded)
        {
            isGrounded = true;
            // Maybe for future implementation on volume control based on velocity
            // if (verticalVelocity > 1)
            // {
            //Debug.Log("Velocity.y = " + verticalVelocity);
            GetComponent<PlayerCollisionSounds>().PlayBounceSound(verticalVelocity);
            // }
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if ((other.gameObject.layer == 6 || other.gameObject.layer == 8) && isGrounded)
        {
            isGrounded = false;
        }
    }
}
