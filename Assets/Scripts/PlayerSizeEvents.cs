using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PlayerSizeEvents : MonoBehaviour
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

    public static PlayerSizeEvents instance;
    private void Awake()
    {
        if (instance == null) instance = this; else
        {
            Destroy(this);
        }
    }

    public event Action<int> PlayerCollision;

    public void OnPlayerCollision(int instanceId)
    {
        Debug.Log("OnPlayerCollision in PlayerSizeEvents - id: " + instanceId);
        PlayerCollision?.Invoke(instanceId);
    }

}
