using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBounceSounds : MonoBehaviour
{
    public bool isGrounded = false;
    public float listenerSpeed;

    private void Start()
    {
        listenerSpeed = GetComponent<Rigidbody>().velocity.magnitude;
    }

    private void OnCollisionEnter(Collision other)
    {
        if ((other.gameObject.layer == 6 || other.gameObject.layer == 8) && !isGrounded)
        {
            isGrounded = true;
            if (listenerSpeed > 1)
            {
                GetComponent<PlayerCollisionSounds>().PlayBounceSound();
            }
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
