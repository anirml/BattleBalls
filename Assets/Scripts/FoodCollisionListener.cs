using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodCollisionListener : MonoBehaviour
{
    private int listenerId;
    private float listenerCurrentScale;
    private Vector3 scaleIncrease;

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("Start in PlayerCollisionListener");
        listenerCurrentScale = this.gameObject.transform.localScale.x;
        listenerId = this.gameObject.GetInstanceID();

        // calls Event from singleton
        PlayerEvents.instance.FoodAbsorb += Grow;
    }

    void Grow(int triggerId, float scaleAverage)
    {
        // Makes sure only relevant objects reacts to the invoke by checking ids
        if(triggerId == listenerId)
        {
            // Debug.Log("TriggerScale for food id: - " + triggerId + " = " + scaleAverage);

            scaleIncrease = new Vector3(scaleAverage, scaleAverage, scaleAverage);

            transform.localScale += scaleIncrease;

            listenerCurrentScale = transform.localScale.x;
            GetComponent<Rigidbody>().mass = CalculateMassChange(listenerCurrentScale);
            
        }
    }
    float CalculateMassChange(float currentScale)
    {
        //float massChange = Mathf.Pow(currentScale, 0.15f);
        //float massChange = Mathf.Pow(currentScale, (1f/3f));
        float massChange = Mathf.Pow(currentScale, 3f);
        return massChange;
    }

}
