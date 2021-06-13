using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempScriptPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Id for player: " + this.GetInstanceID());
    }
}
