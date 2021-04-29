using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody rb;

    public Transform camPivot;
    float heading = 0;
    public Transform cam;

    public float speed = 5.0f;
    private Vector3 force;
    private Vector3 camF;
    private Vector3 camR;

    Vector2 input;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        force = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        heading += Input.GetAxis("Mouse X") * Time.deltaTime * 180;

        camPivot.rotation = Quaternion.Euler(0, heading, 0);
        input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        //input = Vector2.ClampMagnitude(input, 1);

        camF = cam.forward;
        camR = cam.right;

        camF.y = 0;
        camR.y = 0;
        camF = camF.normalized;
        camR = camR.normalized;

        //transform.position += new Vector3(input.x,0,input.y) *Time.deltaTime*5;

        //transform.position += (camF * input.y + camR * input.x) * Time.deltaTime * 5;
        Debug.Log(camF);
        Debug.Log(camR);
        //force = new Vector3(camF.x, 0, camR.y);
        // force.x = Input.GetAxis("Horizontal");
        // force.z = Input.GetAxis("Vertical");
        //force.Normalize();
        input = input.normalized;
        //input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        //input = Vector2.ClampMagnitude(input, 1);

        //transform.position += new Vector3(input.x,0,input.y)*Time.deltaTime*5;
    }

    private void FixedUpdate()
    {
        rb.AddForce((camF * input.y + camR * input.x) * Time.deltaTime * speed * 100);
        //transform.position += (camF * input.y + camR * input.x) * Time.deltaTime * 5;
    }
}
