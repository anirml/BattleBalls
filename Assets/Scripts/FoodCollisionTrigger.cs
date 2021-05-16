using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodCollisionTrigger : MonoBehaviour
{

    private int otherPlayerId;
    private Vector3 scale;
    private float scaleAverage;
    

    private void OnCollisionEnter(Collision other)
    {

        // Debug.Log("OnTriggerEnter in FoodCollisionTrigger");
        if (other.gameObject.tag == "Player")
        {
            // Debug.Log("Collided with Food!");

            otherPlayerId = other.gameObject.GetInstanceID();
            scale = this.transform.localScale;
            scaleAverage = (scale.x * scale.y * scale.z)/3;

            OnFoodCollisionTrigger(otherPlayerId, scaleAverage);
        }
    }

    void OnFoodCollisionTrigger(int otherId, float scaleAverage)
    {
        // Debug.Log("OnFoodCollisionTrigger in FoodCollisionTrigger - Player id: " + otherId);

        PlayerEvents.instance.OnFoodAbsorb(otherId, scaleAverage);
        DisableFood();
    }

    void DisableFood()
    {
        this.gameObject.SetActive(false);
        FoodManager.Instance.StartRespawnTime(this.gameObject);
        
    }
}
