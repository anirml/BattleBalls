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
        listenerCurrentScale = this.gameObject.transform.localScale.x;
        listenerRigidBody = this.gameObject.GetComponent<Rigidbody>();

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

            Vector3 scaleIncrease = CalculateScaleChange(listenerSpeed, triggerSpeed, listenerCurrentScale, triggerCurrentScale);
            
            this.gameObject.transform.localScale += scaleIncrease;
            listenerCurrentScale = this.gameObject.transform.localScale.x;

            listenerRigidBody.mass = CalculateMassChange(listenerCurrentScale);
        }
    }

    Vector3 CalculateScaleChange(float listenerSpeed, float triggerSpeed, float listenerScale, float triggerScale)
    {
        if (triggerSpeed < listenerSpeed)
        {
            Debug.Log("ListenerSpeed > TriggerSpeed for id: " + listenerId + " Speed: " + relativeSpeed/3);
            relativeSpeed = (listenerSpeed - triggerSpeed) / speedModifier; // Subject to change
        }
        if (listenerSpeed < triggerSpeed)
        {
            Debug.Log("TriggerSpeed > ListenerSpeed for id: " + listenerId + " Speed: " + relativeSpeed/3);
            relativeSpeed = (triggerSpeed - listenerSpeed) / speedModifier; // Subject to change
        }

        // Needs brainstorming
        float scale = listenerScale*relativeSpeed*triggerScale;

        return new Vector3(scale, scale, scale);
    }

    float CalculateMassChange(float currentScale)
    {
        float massChange = Mathf.Pow(currentScale,0.15f);
        return massChange;
    }

    // Add force based on the normalized relative positions
}
