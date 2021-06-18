using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodCollisionTrigger : MonoBehaviour
{

    private int otherPlayerId;
    private Vector3 scale;
    private float scaleAverage;
    public int eatingMultiplier;

    private void OnCollisionEnter(Collision other)
    {
        // Debug.Log("OnTriggerEnter in FoodCollisionTrigger");
        if (other.gameObject.tag == "Player")
        {
            otherPlayerId = other.gameObject.GetInstanceID();
            scale = this.transform.localScale;
            scaleAverage = (scale.x + scale.y + scale.z)/(3*eatingMultiplier);

            PlayerEvents.instance.OnFoodAbsorb(otherPlayerId, scaleAverage);
            DisableFood();
        }
    }

    void DisableFood()
    {
        this.gameObject.SetActive(false);
        FoodManager.Instance.StartRespawnTime(this.gameObject);
    }
}
