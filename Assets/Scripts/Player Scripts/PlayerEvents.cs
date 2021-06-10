using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Photon.Pun;

public class PlayerEvents : MonoBehaviourPun
{

    public static PlayerEvents instance;
    
    // Singleton
    private void Awake()
    {
        if (instance == null) instance = this; else
        {
            Destroy(this);
        }
    }

    // first int is Id of collision object, second int is own Id, first float is trigger speed, Vector3 is the collision direction, 
    // Transform is the trigger position & scale, the second Vector3 is the velocity
    public event Action<int, int, float, Vector3, Transform, Vector3> PlayerCollision;
    // first int is Id of object, float is averaged scale
    public event Action<int, float> FoodAbsorb;

    public event Action<float, int> LoserCollision;
    //
    public event Action PlayerDeath;

    public event Action PlayerRespawn;


    public void OnPlayerCollision(int otherId, int ownId, float triggerSpeed, Vector3 collisionDirection, 
    Transform triggerTransform, Vector3 triggerVelocity)
    {
        //Debug.Log("OnPlayerCollision in PlayerSizeEvents - id: " + instanceId);
        PlayerCollision?.Invoke(otherId, ownId, triggerSpeed, collisionDirection, triggerTransform, triggerVelocity);
    }

    public void OnFoodAbsorb(int instanceId, float scaleAverage)
    {
        //Debug.Log("OnFoodAbsorb in PlayerSizeEvents - id: " + instanceId);
        FoodAbsorb?.Invoke(instanceId, scaleAverage);
    }

    public void OnLoserCollision(float loserScaleChange, int loserId)
    {
        LoserCollision?.Invoke(loserScaleChange, loserId);
    }

    public void OnPlayerDeath()
    {
        PlayerDeath?.Invoke();
        PlayerRespawn?.Invoke();
    }

}
