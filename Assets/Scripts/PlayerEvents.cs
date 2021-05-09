using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PlayerEvents : MonoBehaviour
{

    // Singleton
    /* public static PlayerSizeEvents instance;
    private static PlayerSizeEvents i
    {
        get
        {
            if (instance == null) instance = new PlayerSizeEvents();
            return instance;
        }
    } */

    public static PlayerEvents instance;
    private void Awake()
    {
        if (instance == null) instance = this; else
        {
            Destroy(this);
        }
    }

    // first int is Id of object, first float is trigger speed, second float is triggerScale
    public event Action<int, float, float> PlayerCollision;
    // first int is Id of object, float is averaged scale
    public event Action<int, float> FoodAbsorb;


    public void OnPlayerCollision(int instanceId, float triggerSpeed, float triggerScale)
    {
        //Debug.Log("OnPlayerCollision in PlayerSizeEvents - id: " + instanceId);
        PlayerCollision?.Invoke(instanceId, triggerSpeed, triggerScale);
    }

    public void OnFoodAbsorb(int instanceId, float scaleAverage)
    {
        Debug.Log("OnFoodAbsorb in PlayerSizeEvents - id: " + instanceId);
        FoodAbsorb?.Invoke(instanceId, scaleAverage);
    }

}
