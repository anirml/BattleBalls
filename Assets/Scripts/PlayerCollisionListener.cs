using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionListener : MonoBehaviour
{
    private int listenerId;
    private int speedModifier = 30;
    private float listenerCurrentScale;
    private float triggerCurrentScale;
    private float listenerSpeed;
    private float relativeSpeed;
    private Vector3 scaleIncrease;


    // Start is called before the first frame update
    void Start()
    {
        listenerId = this.gameObject.GetInstanceID();
        listenerCurrentScale = this.gameObject.transform.localScale.x;

        // Calls Event from singleton
        PlayerSizeEvents.instance.PlayerCollision += ChangeSize;
    }

    void FixedUpdate()
    {
        listenerSpeed = this.gameObject.GetComponent<Rigidbody>().velocity.magnitude;
    }

    void ChangeSize(int triggerId, float triggerSpeed, float triggerCurrentScale)
    {
        // Makes sure only relevant objects reacts to the invoke by checking ids
        if (triggerId == listenerId)
        {
            //Debug.Log("TriggerVelocity: " + triggerSpeed);
            //Debug.Log("ListenerVelocity for id: " + listenerId + " = " + listenerSpeed);

            scaleIncrease = CalculateScaleChange(listenerSpeed, triggerSpeed, listenerCurrentScale, triggerCurrentScale);

            this.gameObject.transform.localScale += scaleIncrease;
        }
    }

    Vector3 CalculateScaleChange(float listenerSpeed, float triggerSpeed, float listenerScale, float triggerScale)
    {
        if (triggerSpeed < listenerSpeed)
        {
            Debug.Log("ListenerSpeed > TriggerSpeed for id: " + listenerId);
            relativeSpeed = (listenerSpeed - triggerSpeed) / speedModifier; // Subject to change
        }
        else
        {
            Debug.Log("TriggerSpeed > ListenerSpeed for id: " + listenerId);
            relativeSpeed = (triggerSpeed - listenerSpeed) / speedModifier; // Subject to change
        }

        float scale = 0.2f;
        return new Vector3(scale, scale, scale);
    }

    // Add force based on the normalized relative positions
}
