using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerBounceSounds : MonoBehaviourPun
{
    public bool isGrounded = false;
    public float verticalVelocity;

    private void Start()
    {
        var isMine = photonView.IsMine;
    }
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
            if (photonView.IsMine)
            {
                GetComponent<PlayerCollisionSounds>().PlayBounceSound(verticalVelocity);
            }
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
