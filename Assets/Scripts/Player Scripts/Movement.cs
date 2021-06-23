using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using TMPro;

public class Movement : MonoBehaviourPun
{
    public Rigidbody rb;

    public int mouseSensivityX = 360;
    public int mouseSensivityY = 180;

    public Transform camPivot;
    float heading = 0;
    float tilt = 15;
    public Transform cam;
    public AudioClip speedBuffSound;

    public float speed = 5.0f;
    public float speedBoost = 1200;

    private Vector3 camF;
    private Vector3 camR;
    Vector2 input;
    private bool gameIsPaused;
    private GameObject pauseMenu;


    private Image imageCooldown;
    private GameObject imageC;
    private GameObject imageC2;
    private GameObject textCD;
    private TMP_Text textCooldown;
    private int cd = 0;

    //Variables for cooldowntimer
    private bool isCooldown = false;
    private float cooldownTime = 30.0f;
    private float cooldownTimer = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        var isMine = photonView.IsMine;

        //camPivot.gameObject.SetActive(isMine);
        camPivot.gameObject.SetActive(true);
        cam.gameObject.SetActive(isMine);

        rb = GetComponent<Rigidbody>();

        pauseMenu = GameObject.Find("CanvasMenu");

        imageC = GameObject.FindGameObjectWithTag("SpeedBoostCanvas");
        imageC2 = imageC.transform.GetChild(0).GetChild(0).gameObject;

        imageCooldown = imageC2.GetComponent<Image>();

        textCD = imageC.transform.GetChild(0).GetChild(1).gameObject;
        textCooldown = textCD.GetComponent<TMP_Text>();

        imageCooldown.fillAmount = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        gameIsPaused = pauseMenu.GetComponent<PauseMenu>().gameIsPaused;

        if (photonView.IsMine && !gameIsPaused)
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

            if (Input.GetKeyDown(KeyCode.E) && isCooldown == false)
            {
                UseSpeedBoost();
            }
            if (isCooldown)
            {
                ApplyCooldown();
            }
        }

    }

    private void FixedUpdate()
    {
        if (!gameIsPaused && cd == 1)
        {
            rb.AddForce((camF * input.y + camR * input.x) * Time.deltaTime * speed * 1200 * rb.mass);
            //Debug.Log("SPEED BUFFF"); delete later
        }
        if (!gameIsPaused && cd == 0)
        {
            rb.AddForce((camF * input.y + camR * input.x) * Time.deltaTime * speed * 100 * rb.mass);
        }
    }

    void ApplyCooldown()
    {
        //subtrack time since last called
        cooldownTimer -= Time.deltaTime;

        if (cooldownTimer < 0.0f)
        {
            isCooldown = false;
            textCooldown.gameObject.SetActive(false);
            imageCooldown.fillAmount = 0.0f;
        }
        else
        {
            textCooldown.text = Mathf.RoundToInt(cooldownTimer).ToString();
            imageCooldown.fillAmount = cooldownTimer / cooldownTime;
        }
    }

    public void UseSpeedBoost()
    {
        if (isCooldown)
        {

        }
        else
        {
            cooldownTimer = cooldownTime;
            textCooldown.text = "30";
            textCooldown.gameObject.SetActive(true);
            StartCoroutine(cDelay());
        }
    }

    IEnumerator cDelay()
    {
        cd = 1;
        Debug.Log("111111");
        AudioSource.PlayClipAtPoint(speedBuffSound,this.transform.position);
        yield return new WaitForSeconds(0.5f);
        Debug.Log("222222");
        cd = 0;
        isCooldown = true;

    }

}