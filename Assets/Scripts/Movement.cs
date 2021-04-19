using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    private Rigidbody rb;
    private Vector3 local;
    private float x;
    private float z;
    public float speed = 5.0f;
    private Vector3 direction;
    private Vector3 pos;
    public float radius;
    public float ballY;
    public LayerMask groundLayer = new LayerMask();

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //cl = GetComponent<SphereCollider>();
        direction = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        local = transform.localScale;
        ballY = local.y;

        radius = (ballY/2) * 1.2f;

        pos = transform.position;

        if (Physics.CheckSphere(pos, radius, groundLayer))
        {
            direction.x = Input.GetAxis("Horizontal");
            direction.z = Input.GetAxis("Vertical");
            direction.Normalize();
        }
     
    }

    private void FixedUpdate()
    {
            rb.AddForce(direction * speed);
    }


}
