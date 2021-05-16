using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodOnSpawn : MonoBehaviour
{
    public GameObject foodPrefab;

    Vector3 newScale;
    float minRandom = 0.25f;
    float maxRandom = 1.5f;

    public int maxFoods;
    public static float globalNumberOfFoods;
    // Possible feature?
    // public int foodSpawnRate;

    // Start is called before the first frame update, onEnable when the script is enabled for future object pooling implementation
    //void Awake()

    void onEnable()
    {
        RandomizeFoodScale();
        RandomizePositionRotation();

    }

    void RandomizeFoodScale()
    {
        float x = Random.Range(minRandom, maxRandom);
        float y = Random.Range(minRandom, maxRandom);
        float z = Random.Range(minRandom, maxRandom);

        newScale = new Vector3(x,y,z);

        this.transform.localScale = newScale;
    }

    void RandomizePositionRotation()
    {
        // Should probably be put somewhere else...
        GameObject gizmoObj = GameObject.Find("FoodSpawnGizmo");
        OnDrawGizmoSelected gizmoScript = gizmoObj.GetComponent<OnDrawGizmoSelected>();

        Vector3 center = gizmoScript.center;
        Vector3 size = gizmoScript.size;

        Vector3 pos = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), Random.Range(1, 1), Random.Range(-size.z / 2, size.z / 2));

    }
}
