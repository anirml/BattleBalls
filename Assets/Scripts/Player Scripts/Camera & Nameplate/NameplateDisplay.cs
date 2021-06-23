using TMPro;
using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

public class NameplateDisplay : MonoBehaviourPun
{
    [SerializeField] private Text nameText;

    Quaternion rotation;
    private int randInt;

    //public GameObject player;

    private void Start()
    {
        //THIS RUNS ON ALL CLIENTS EVERYTIME A CLIENT JOINS!"!"   

        nameText.text = photonView.Owner.NickName;

        SetName(randInt);
    }

    void Awake()
    {
        rotation = transform.rotation;
    }

    void FixedUpdate()
    {
        transform.rotation = rotation;
    }
    private void SetName(int randInt)
    {

        // Debug.Log(randInt);
        if (randInt == 0)
        {
            nameText.text = photonView.Owner.NickName;
            //PhotonNetwork.NickName = nameText.text;
            //PlayerPrefs.SetString("NickName", nameText.text);
            //Debug.Log(PhotonNetwork.NickName);//DELETE LATER
        }
        if (randInt != 0)
        {
            nameText.text = photonView.Owner.NickName + randInt;
            //PhotonNetwork.NickName = nameText.text;
            //PlayerPrefs.SetString("NickName", nameText.text);
            //Debug.Log(PhotonNetwork.NickName);//DELETE LATER
        }
    }
}