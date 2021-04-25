using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodOnSpawn : MonoBehaviour
{
    Vector3 newScale;
    float minRandom = 0.25f;
    float maxRandom = 2.5f;

    // Start is called before the first frame update, onEnable when the script is enabled for future object pooling implementation
    //void onEnable()
    void Awake()
    {
        newScale = new Vector3(1f,1f,0.25f);
        RandomizeScale();
        RandomizePositionRotation();
    }

    void RandomizeScale()
    {
        float x = Random.Range(minRandom, maxRandom);
        float y = Random.Range(minRandom, maxRandom);
        float z = Random.Range(minRandom, maxRandom);

        newScale = new Vector3(x,y,z);

        this.transform.localScale = newScale;
    }

    void RandomizePositionRotation()
    {

    }
}
