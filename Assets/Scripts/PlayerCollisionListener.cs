using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionListener : MonoBehaviour
{
    private int listenerId;
    [SerializeField]
    private int scaleModifier = 30; // higher means more speed needed to steal mass
    [SerializeField]
    private float scaleChangeThreshold = 0.4f; // 0-1 equals percentage of max scale transfer 1 is for testing purposes
    [SerializeField]
    private float speedModifier = 50; // changes the force applied to collision knockback
    [SerializeField]
    private float maxPlayerSize = 10; // 3d scale in meters (diameter)
    private float listenerCurrentScale;
    private float listenerSpeed;
    private Vector3 listenerVelocity; 
    private Rigidbody listenerRigidBody;


    // Start is called before the first frame update
    void Start()
    {
        listenerId = this.gameObject.GetInstanceID();
        listenerCurrentScale = transform.localScale.x;
        listenerRigidBody = GetComponent<Rigidbody>();
        listenerRigidBody.mass = CalculateMassChange(listenerCurrentScale);

        // Calls Events from singleton (subscribe)
        PlayerEvents.instance.PlayerCollision += ApplyPushback;
        PlayerEvents.instance.PlayerCollision += ChangeSize;
        PlayerEvents.instance.LoserCollision += ChangeCollisionLoserSize;
    }

    void FixedUpdate()
    {
        listenerSpeed = GetComponent<Rigidbody>().velocity.magnitude;
        listenerVelocity = GetComponent<Rigidbody>().velocity;
    }

    void ApplyPushback(int passedListenerId, int triggerId, float triggerSpeed, Vector3 collisionDirection, 
    Transform triggerTransform, Vector3 triggerVelocity)
    {
        //Debug.Log("ApplyPushback passedListenerId: " + passedListenerId + " listenerId: " + listenerId);
        // Makes sure only relevant objects reacts to the invoke by checking ids
        if (passedListenerId == listenerId)
        {
            float relativeSpeed = CalculateRelativeVelocity(triggerVelocity, GetComponent<Rigidbody>().velocity);
            //Debug.Log("RelativeSpeed manual: " + relativeSpeed);

            GetComponent<Rigidbody>().AddForce(collisionDirection * relativeSpeed * listenerRigidBody.mass * (30 + speedModifier));
            // Adds vertical force
            GetComponent<Rigidbody>().AddForce(new Vector3(0, 1, 0) * relativeSpeed * listenerRigidBody.mass * 10);
        }
    }

    void ChangeSize(int passedListenerId, int triggerId, float triggerSpeed, Vector3 collisionDirection, 
    Transform triggerTransform, Vector3 triggerVelocity)
    {
        // Makes sure only relevant objects reacts to the invoke by checking ids
        if (passedListenerId == listenerId)
        {
            float triggerScale = triggerTransform.localScale.x;
            Vector3 scaleIncrease = CalculateScaleChange(listenerSpeed, triggerSpeed, listenerCurrentScale, 
            triggerScale, triggerVelocity, triggerId);

            // Checks for player death (no size)
            if (listenerCurrentScale - scaleIncrease.x < 0.1f)
            {
                PlayerEvents.instance.OnPlayerDeath();
                return;
            }

            // Checks for player max size
            if (listenerCurrentScale + scaleIncrease.x > maxPlayerSize)
            {
                ChangeScale(new Vector3(maxPlayerSize, maxPlayerSize, maxPlayerSize));
                return;
            }

            ChangeScale(scaleIncrease);
        }
    }

    void ChangeCollisionLoserSize(float loserScaleChange, int loserId)
    {
        if (loserId == listenerId)
        {
            Vector3 scaleDecrease = new Vector3(loserScaleChange, loserScaleChange, loserScaleChange);
            ChangeScale(scaleDecrease);
        }
    }

    void ChangeScale(Vector3 scaleChange)
    {
        transform.localScale += scaleChange;

        listenerCurrentScale = transform.localScale.x;
        listenerRigidBody.mass = CalculateMassChange(listenerCurrentScale);
    }

    Vector3 CalculateScaleChange(float listenerSpeed, float triggerSpeed, float listenerScale,
     float triggerScale, Vector3 triggerVelocity, int triggerId)
    {
        float relativeSpeed = CalculateRelativeVelocity(triggerVelocity, listenerVelocity);
        float scaleChange = CalculateScaleChangeFactor(relativeSpeed);
        float newListenerScaleIncrease = 0;
        float newTriggerScaleIncrease = 0;

        if (triggerSpeed <= listenerSpeed)
        {
            newListenerScaleIncrease = (triggerScale * scaleChange);
            newTriggerScaleIncrease = (listenerScale * -scaleChange);
            PlayerEvents.instance.OnLoserCollision(newTriggerScaleIncrease, triggerId);
        }

        return new Vector3(newListenerScaleIncrease, newListenerScaleIncrease, newListenerScaleIncrease);
    }

    float CalculateScaleChangeFactor(float relativeSpeed)
    {
        // logistic growth of scale
        float scaleChange = (2/(1+Mathf.Exp(-relativeSpeed/scaleModifier))-1)*scaleChangeThreshold;
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
        //float massChange = Mathf.Pow(currentScale, 3f);
        float massChange = 4/3 * Mathf.PI * Mathf.Pow((currentScale/2), 3f);
        return massChange;
    }
}
