using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodOnSpawn : MonoBehaviour
{
    public GameObject foodPrefab;
    public Vector3 center;
    public Vector3 size;

    Vector3 newScale;
    float minRandom = 0.25f;
    float maxRandom = 1.5f;

    public int maxFoods;
    public static float globalNumberOfFoods;
    // Possible feature?
    // public int foodSpawnRate;

    // Start is called before the first frame update, onEnable when the script is enabled for future object pooling implementation
    //void onEnable()

    void Awake()
    {
        // newScale = new Vector3(1f,1f,0.25f);

        if (globalNumberOfFoods <= maxFoods) 
        {
            for (int i = 0; i < maxFoods; i++)
            {
                // RandomizeFoodScale();
                RandomizePositionRotation();
            }
        }

        // RandomizeFoodScale();
        // RandomizePositionRotation();
    }

    void RandomizeFoodScale()
    {
        float x = Random.Range(minRandom, maxRandom);
        float y = Random.Range(minRandom, maxRandom);
        float z = Random.Range(minRandom, maxRandom);

        newScale = new Vector3(x,y,z);

        this.transform.localScale = newScale;
    }

    void OnDrawGizmosSelected() 
    {
        Gizmos.color = new Color(1,0,0,0.5f);
        Gizmos.DrawCube(center, size);
    }

    void RandomizePositionRotation()
    {
        Vector3 pos = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), Random.Range(1, 1), Random.Range(-size.z / 2, size.z / 2));

        Instantiate(foodPrefab, pos, Quaternion.identity);
    }
}
