using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class FoodCollisionListener : MonoBehaviourPun
{
    private int listenerId;
    private float listenerCurrentScale;
    private int maxPlayerSize;
    private Vector3 scaleIncrease;

    // Start is called before the first frame update
    void Start()
    {
        var isMine = photonView.IsMine;

        maxPlayerSize = GetComponent<PlayerCollisionListener>().maxPlayerSize;

        //Debug.Log("Start in PlayerCollisionListener");
        listenerCurrentScale = this.gameObject.transform.localScale.x;
        listenerId = this.gameObject.GetInstanceID();

        // calls Event from singleton (subscribe)
        PlayerEvents.instance.FoodAbsorb += Grow;
    }

    void Grow(int triggerId, float scaleAverage)
    {
        // Makes sure only relevant objects reacts to the invoke by checking ids
        if (triggerId == listenerId)
        {
            listenerCurrentScale = transform.localScale.x;
            // Debug.Log("TriggerScale for food id: - " + triggerId + " = " + scaleAverage);

            scaleIncrease = new Vector3(scaleAverage, scaleAverage, scaleAverage);

            //Debug.Log("MaxSize check: " + listenerCurrentScale + scaleIncrease.x);
            // Checks for player max size
            if (listenerCurrentScale + scaleIncrease.x > maxPlayerSize)
            {
                transform.localScale = new Vector3(maxPlayerSize, maxPlayerSize, maxPlayerSize);

                listenerCurrentScale = maxPlayerSize;
                GetComponent<Rigidbody>().mass = CalculateMassChange(maxPlayerSize);
                FoodPickupEffects();
                return;
            }

            transform.localScale += scaleIncrease;

            listenerCurrentScale = transform.localScale.x;
            GetComponent<Rigidbody>().mass = CalculateMassChange(listenerCurrentScale);

            FoodPickupEffects();
        }
    }

    float CalculateMassChange(float currentScale)
    {
        //float massChange = Mathf.Pow(currentScale, 3f);
        float massChange = 4 / 3 * Mathf.PI * Mathf.Pow((currentScale / 2), 3f);
        return massChange;
    }

    void FoodPickupEffects()
    {
        if (photonView.IsMine)
        {
            GetComponent<PlayerCollisionSounds>().PlayPickUpFoodSound();
        }
    }

}
