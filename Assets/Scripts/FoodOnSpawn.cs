using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodOnSpawn : MonoBehaviour
{
    public GameObject foodPrefab;

    Vector3 newScale;

    // Vector3 center = new Vector3(0,0.5f,0);
    Vector3 center;
    // Vector3 size = new Vector3(999,1,999);
    Vector3 size;
    
    float minRandom = 0.2f;
    float maxRandom = 1f;

    // Possible feature?
    // public int foodSpawnRate;

    // Start is called before the first frame update, onEnable when the script is enabled for future object pooling implementation
    //void Awake()


    void OnEnable()
    {
        RandomizeFoodScale();
        RandomizeFoodColor();
        RandomizePositionRotation();
    }

    void RandomizeFoodScale()
    {
        float x = Random.Range(minRandom, maxRandom);
        float y = Random.Range(minRandom, maxRandom);
        float z = Random.Range(minRandom, maxRandom);

        newScale = new Vector3(x, y, z);

        this.transform.localScale = newScale;
    }

    void RandomizePositionRotation()
    {
        center = FoodManager.Instance.center;
        size = FoodManager.Instance.size;

        Vector3 pos = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), Random.Range(1, 1), Random.Range(-size.z / 2, size.z / 2));
        this.transform.localPosition = pos;
        
    }

    void RandomizeFoodColor()
    {
                                                        //   ColorHSV(minHue, maxHue, minSaturation, maxSaturation, minValue, maxValue, minAlpha, maxAlpha)
        this.GetComponent<Renderer>().material.SetColor("_EmissionColor", Random.ColorHSV(0f, 1f, 1f, 1f, 0.75f, 1f) * 4f);
    }
}
