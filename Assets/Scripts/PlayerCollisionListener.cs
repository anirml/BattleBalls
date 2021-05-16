using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionListener : MonoBehaviour
{
    private int listenerId;
    [SerializeField]
    private int speedModifier = 30;
    private float listenerCurrentScale;
    private float listenerSpeed;
    private float relativeSpeed;
    private Rigidbody listenerRigidBody;


    // Start is called before the first frame update
    void Start()
    {
        listenerId = this.gameObject.GetInstanceID();
        listenerCurrentScale = transform.localScale.x;
        listenerRigidBody = GetComponent<Rigidbody>();

        // Calls Events from singleton
        PlayerEvents.instance.PlayerCollision += ApplyPushback;
        PlayerEvents.instance.PlayerCollision += ChangeSize;
    }

    void FixedUpdate()
    {
        listenerSpeed = GetComponent<Rigidbody>().velocity.magnitude;
    }

    void ApplyPushback(int passedListenerId, float triggerSpeed, Vector3 collisionDirection, Transform triggerTransform)
    {
        Debug.Log("ApplyPushback passedListenerId: " + passedListenerId + " listenerId: " + listenerId);
        // Makes sure only relevant objects reacts to the invoke by checking ids
        if (passedListenerId == listenerId)
        {
            Debug.Log("ApplyPushback direction: " + collisionDirection + " speed: " + triggerSpeed*100);

            // triggerSpeed * 100 is an aribtary number; subject to change - needs testing
            GetComponent<Rigidbody>().AddForce(collisionDirection * 1500);
            // Adds vertical force
            GetComponent<Rigidbody>().AddForce(new Vector3(0, 1, 0) * 3);
        }
    }

    void ChangeSize(int triggerId, float triggerSpeed, Vector3 collisionDirection, Transform triggerTransform)
    {
        // Makes sure only relevant objects reacts to the invoke by checking ids
        if (triggerId == listenerId)
        {
            Debug.Log("TriggerVelocity: " + triggerSpeed);
            Debug.Log("ListenerVelocity for id: " + listenerId + " = " + listenerSpeed);

            float triggerScale = triggerTransform.localScale.x;
            Vector3 scaleIncrease = CalculateScaleChange(listenerSpeed, triggerSpeed, listenerCurrentScale, triggerScale);

            transform.localScale += scaleIncrease;
            listenerCurrentScale = transform.localScale.x;

            listenerRigidBody.mass = CalculateMassChange(listenerCurrentScale);
        }
    }

    Vector3 CalculateScaleChange(float listenerSpeed, float triggerSpeed, float listenerScale, float triggerScale)
    {
        if (triggerSpeed < listenerSpeed)
        {
            Debug.Log("ListenerSpeed > TriggerSpeed for id: " + listenerId + " Speed: " + relativeSpeed / 3);
            //relativeSpeed = (listenerSpeed - triggerSpeed) / speedModifier; // Subject to change
            relativeSpeed = 0.2f;
        }
        if (listenerSpeed < triggerSpeed)
        {
            Debug.Log("TriggerSpeed > ListenerSpeed for id: " + listenerId + " Speed: " + relativeSpeed / 3);
            //relativeSpeed = (triggerSpeed - listenerSpeed) / speedModifier; // Subject to change
            relativeSpeed = -0.2f;
        }

        // Needs brainstorming
        float scale = relativeSpeed;
        //float scale = listenerScale * relativeSpeed * triggerScale;

        return new Vector3(scale, scale, scale);
    }

    float CalculateMassChange(float currentScale)
    {
        float massChange = Mathf.Pow(currentScale, 0.15f);
        return massChange;
    }

    // Add force based on the normalized relative positions
}