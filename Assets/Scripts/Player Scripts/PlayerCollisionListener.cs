using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;

public class PlayerCollisionListener : MonoBehaviourPun
{
    public int scaleModifier; // higher means more speed needed to steal mass
    public float scaleChangeThreshold; // 0-1 equals percentage of max scale transfer 1 is for testing purposes
    public float speedModifier; // changes the force applied to collision knockback
    public float minSize;
    public int maxPlayerSize; // 3d scale in meters (diameter)
    public int knockbackModifier;

    public GameObject collisionEffect;

    private int listenerId;
    private float listenerCurrentScale;
    private Rigidbody listenerRigidBody;
    private float listenerSpeed;
    private Vector3 listenerVelocity;

    private bool isWinner = true;

    // Start is called before the first frame update
    void Start()
    {
        var isMine = photonView.IsMine;

        listenerId = this.gameObject.GetInstanceID();
        listenerCurrentScale = transform.localScale.x;
        listenerRigidBody = GetComponent<Rigidbody>();
        listenerRigidBody.mass = CalculateMassChange(listenerCurrentScale);

        // Calls Events from singleton (subscribe)
        PlayerEvents.instance.PlayerCollision += ChangeCollisionWinnerSize;
        PlayerEvents.instance.PlayerCollision += ApplyPushback;
        PlayerEvents.instance.LoserCollision += ChangeCollisionLoserSize;
    }

    void Update()
    {
        listenerSpeed = GetComponent<Rigidbody>().velocity.magnitude;
        listenerVelocity = GetComponent<Rigidbody>().velocity;
    }

    void ApplyPushback(int passedListenerId, int triggerId, float triggerSpeed, Vector3 collisionDirection,
    Transform triggerTransform, Vector3 triggerVelocity)
    {
        // Makes sure only relevant objects reacts to the invoke by checking ids
        if (passedListenerId == listenerId)
        {
            float relativeSpeed = CalculateRelativeVelocity(triggerVelocity, GetComponent<Rigidbody>().velocity);

            GetComponent<Rigidbody>().AddForce(collisionDirection * relativeSpeed * listenerRigidBody.mass * (speedModifier) * knockbackModifier);
            // Adds vertical force
            GetComponent<Rigidbody>().AddForce(new Vector3(0, 1, 0) * relativeSpeed * listenerRigidBody.mass * 2 * knockbackModifier);
        }
    }

    float CalculateScaleChange(float triggerSpeed, float listenerScale,
     float triggerScale, Vector3 triggerVelocity, int triggerId)
    {
        listenerVelocity = GetComponent<Rigidbody>().velocity;
        listenerSpeed = GetComponent<Rigidbody>().velocity.magnitude;

        float relativeSpeed = CalculateRelativeVelocity(triggerVelocity, listenerVelocity);
        float scaleChange = CalculateScaleChangeFactor(relativeSpeed);
        float newListenerScaleIncrease = 0;
        float newTriggerScaleIncrease = 0;

        if (triggerSpeed <= listenerSpeed)
        {
            newListenerScaleIncrease = (triggerScale * scaleChange);
            newTriggerScaleIncrease = (listenerScale * -scaleChange);
            Debug.Log("newListenerScale = " + newListenerScaleIncrease + " newTriggerScaleDecrease = " + newTriggerScaleIncrease);
            PlayerEvents.instance.OnLoserCollision(newTriggerScaleIncrease, triggerId);
        }

        CollisionEffects(this.transform);
        isWinner = true;
        return newListenerScaleIncrease;
    }

    void ChangeCollisionWinnerSize(int passedListenerId, int triggerId, float triggerSpeed, Vector3 collisionDirection,
    Transform triggerTransform, Vector3 triggerVelocity)
    {
        // Makes sure only relevant objects reacts to the invoke by checking ids
        if (passedListenerId == listenerId)
        {
            listenerCurrentScale = transform.localScale.x;
            float triggerScale = triggerTransform.localScale.x;

            float scaleIncrease = CalculateScaleChange(triggerSpeed, listenerCurrentScale,
            triggerScale, triggerVelocity, triggerId);

            //CameraShake.Shake(0.8f, 1f); //Camera shake for a later date

            // Checks for player max size
            if ((listenerCurrentScale + scaleIncrease) > maxPlayerSize)
            {
                transform.localScale = new Vector3(maxPlayerSize, maxPlayerSize, maxPlayerSize);

                listenerCurrentScale = maxPlayerSize;
                listenerRigidBody.mass = CalculateMassChange(maxPlayerSize);
                CollisionEffects(this.transform);
                isWinner = true;
                return;
            }

            ChangeScale(new Vector3(scaleIncrease, scaleIncrease, scaleIncrease));
        }
    }

    void ChangeCollisionLoserSize(float loserScaleChange, int loserId)
    {
        if (loserId == listenerId)
        {
            isWinner = false;
            Vector3 scaleDecrease = new Vector3(loserScaleChange, loserScaleChange, loserScaleChange);
            // Vector3 playerPos = transform.localPosition;

            // Debug.Log("new scale for player: " + listenerId + " = " + (listenerCurrentScale + scaleDecrease.x));
            // Checks for player death (no size)
            if ((listenerCurrentScale + scaleDecrease.x) < minSize)
            {
                // PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "Splatter"), playerPos, Quaternion.identity);
                PlayerEvents.instance.OnPlayerDeath(listenerId);
                return;
            }
            ChangeScale(scaleDecrease);
        }
    }

    void ChangeScale(Vector3 scaleChange)
    {
        transform.localScale += scaleChange;

        listenerCurrentScale = transform.localScale.x;
        listenerRigidBody.mass = CalculateMassChange(listenerCurrentScale);
    }

    float CalculateScaleChangeFactor(float relativeSpeed)
    {
        // logistic growth of scale
        float scaleChange = (2 / (1 + Mathf.Exp(-relativeSpeed / scaleModifier)) - 1) * scaleChangeThreshold;
        return scaleChange;
    }

    float CalculateRelativeVelocity(Vector3 triggerVelocity, Vector3 listenerVelocity)
    {
        // pythagoras for 3d
        float relativeVelocityX = Mathf.Pow((triggerVelocity.x - listenerVelocity.x), 2);
        float relativeVelocityY = Mathf.Pow((triggerVelocity.y - listenerVelocity.y), 2);
        float relativeVelocityZ = Mathf.Pow((triggerVelocity.z - listenerVelocity.z), 2);

        float relativeSpeed = Mathf.Sqrt(relativeVelocityX + relativeVelocityY + relativeVelocityZ);
        return relativeSpeed;
    }

    float CalculateMassChange(float currentScale)
    {
        float massChange = 4 / 3 * Mathf.PI * Mathf.Pow((currentScale / 2), 3f);
        return massChange;
    }

    void CollisionEffects(Transform listenerTransform)
    {
        if (isWinner)
        {
            // not working properly
        }

        GetComponent<PlayerCollisionSounds>().PlayRandomCollisionSound();
        isWinner = true;

        if (photonView.IsMine)
        {
            GameObject CollisionEffect = Instantiate(collisionEffect, listenerTransform.localPosition, listenerTransform.rotation);
            collisionEffect.transform.localScale = new Vector3(listenerCurrentScale, listenerCurrentScale, listenerCurrentScale);
        }
    }
}
