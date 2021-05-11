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

    private Vector3 camF;
    private Vector3 camR;

    Vector2 input;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        heading += Input.GetAxis("Mouse X") * Time.deltaTime * 180;

        camPivot.rotation = Quaternion.Euler(0, heading, 0);
        input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        camF = cam.forward;
        camR = cam.right;

        camF.y = 0;
        camR.y = 0;
        camF = camF.normalized;
        camR = camR.normalized;

        input = input.normalized;
    }

    private void FixedUpdate()
    {
        rb.AddForce((camF * input.y + camR * input.x) * Time.deltaTime * speed * 100);
    }
}