using TMPro;
using Photon.Pun;
using UnityEngine;

public class NameplateDisplay : MonoBehaviourPun
{
    [SerializeField] private TextMeshProUGUI nameText;

    Quaternion rotation;
    private int randInt;

    //public GameObject player;

    private void Start()
    {
        //THIS RUNS ON ALL CLIENTS EVERYTIME A CLIENT JOINS!"!"   

        nameText.text = photonView.Owner.NickName;
        // if (photonView.IsMine)
        // {
        // foreach (Player p in PhotonNetwork.PlayerListOthers)
        // {
        //     string nickName = p.NickName;
        //     Debug.Log("Nickname in foreach loop: " + nickName);

        //    Debug.Log("nameText: " + nameText.text + " NICKNAME: " + nickName);
        //    if (nickName == nameText.text)
        //     {
        //PhotonNetwork.NickName = nameText.text;
        //PlayerPrefs.SetString("NickName", nameText.text);
        //Debug.Log(PhotonNetwork.NickName);//DELETE LATER

        //         randInt = Random.Range(1, 1000);
        //          Debug.Log("do something to name!");
        //         break;
        //     }//TODO add error already a player name that!
        //  }

        SetName(randInt);

        //Destroy the script so it dont run on other clients
        //Destroy(GetComponent<NameplateDisplay>);

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