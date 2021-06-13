using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Movement : MonoBehaviourPun
{
    public Rigidbody rb;

    public int mouseSensivityX = 360;
    public int mouseSensivityY = 180;

    public Transform camPivot;
    float heading = 0;
    float tilt = 15;
    public Transform cam;

    public float speed = 5.0f;

    private Vector3 camF;
    private Vector3 camR;

    Vector2 input;
    // Start is called before the first frame update

    void Start()
    {
        var isMine = photonView.IsMine;

        if (cam.gameObject.activeSelf == false)
        {
            camPivot.gameObject.SetActive(isMine);
            cam.gameObject.SetActive(isMine);
        }
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (photonView.IsMine)
        {
            heading += Input.GetAxis("Mouse X") * Time.deltaTime * mouseSensivityX;
            tilt += Input.GetAxis("Mouse Y") * Time.deltaTime * mouseSensivityY;

            tilt = Mathf.Clamp(tilt, -70, 10);

            camPivot.rotation = Quaternion.Euler(-tilt, heading, 0);
            input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

            camF = cam.forward;
            camR = cam.right;

            camF.y = 0;
            camR.y = 0;
            camF = camF.normalized;
            camR = camR.normalized;

            input = input.normalized;
        }
    }

    private void FixedUpdate()
    {
        rb.AddForce((camF * input.y + camR * input.x) * Time.deltaTime * speed * 100 * rb.mass);
    }
}