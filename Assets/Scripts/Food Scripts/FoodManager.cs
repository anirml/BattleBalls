using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodManager : MonoBehaviour
{

    [SerializeField]
    public Vector3 center;
    [SerializeField]
    public Vector3 size;
    [SerializeField]
    public static int maxPlayerSize = 10; // 3d scale in meters (diameter)
    public float maxFoods;
    private float currentNumberOfFoods;
    public float foodRespawnDelay;
    public GameObject food;

    // Singleton that actually works KEK
    public static FoodManager Instance
     {
         get
         {
             if (instance == null)
                 instance = FindObjectOfType(typeof(FoodManager)) as FoodManager;
 
             return instance;
         }
         set
         {
             instance = value;
         }
     }
     private static FoodManager instance;

     private void Start() 
     {
         if (currentNumberOfFoods <= maxFoods) 
        {
            for (int i = 0; i < maxFoods; i++)
            {
                Instantiate(food);
            }
        }
     }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawCube(center, size);
    }

    public void StartRespawnTime(GameObject food)
    {
        StartCoroutine(EnableFood(food, foodRespawnDelay));
    }

    IEnumerator EnableFood(GameObject food, float foodRespawnDelay)
    {
        yield return new WaitForSeconds(foodRespawnDelay);
        food.SetActive(true);
    }


}
