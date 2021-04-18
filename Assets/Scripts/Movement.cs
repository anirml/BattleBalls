using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    private Rigidbody rb;
    private float x;
    private float z;
    private float speed = 5.0f;
    private Vector3 direction;
    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody>();
        direction = new Vector3(0, 0, 0);

    }

    // Update is called once per frame
    //void Update()
    //{
        //horizontalInput = Input.GetAxis("Horizontal");
        //erticalInput = Input.GetAxis("Vertical");
        //Vector3 direction = new Vector3(0, 0, 0);
        //direction.x = Input.GetAxis("Horizontal");
        //direction.z = Input.GetAxis("Vertical");
        //direction.Normalize();
        //rb.AddForce(direction * speed);
    //}

    private void Update()
    {
        //rb.AddForce(new Vector3((horizontalInput/2), 0.0f, (verticalInput/2)) * speed);
        direction.x = Input.GetAxis("Horizontal");
        direction.z = Input.GetAxis("Vertical");
        direction.Normalize();
        rb.AddForce(direction * speed);
    }
}
