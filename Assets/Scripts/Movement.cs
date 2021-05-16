using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Movement : MonoBehaviourPun
{
    public Rigidbody rb;

    public int mouseSensivity = 360;

    public Transform camPivot;
    float heading = 0;
    public Transform cam;

    public float speed = 5.0f;

    private Vector3 camF;
    private Vector3 camR;

    bool isFollowing;

    Vector2 input;
    // Start is called before the first frame update

    public void OnStartFollowing()
    {
        cam = Camera.main.transform;
        isFollowing = true;
    }

    void Start()
    {    

        var isMine = photonView.IsMine;        

        if(cam.gameObject.activeSelf == false){
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
        heading += Input.GetAxis("Mouse X") * Time.deltaTime * mouseSensivity;

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
    }

    private void FixedUpdate()
    {
        rb.AddForce((camF * input.y + camR * input.x) * Time.deltaTime * speed * 100);
    }
}