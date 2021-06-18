using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;
using UnityEngine.UI;
using TMPro;

public class ScoreHandler : MonoBehaviour
{
    public Image pName1;
    public Image pName2;
    public Image pName3;
    public Image pName4;
    public Image pName5;
    public Image pName6;
    public Image pName7;
    public Image pName8;
    public Image pName9;
    public Image pName10;

    public TextMeshProUGUI nText1;
    public TextMeshProUGUI nText2;
    public TextMeshProUGUI nText3;
    public TextMeshProUGUI nText4;
    public TextMeshProUGUI nText5;
    public TextMeshProUGUI nText6;
    public TextMeshProUGUI nText7;
    public TextMeshProUGUI nText8;
    public TextMeshProUGUI nText9;
    public TextMeshProUGUI nText10;

    void Start()
    {
        InvokeRepeating("FindPlayerNames", 0.1f, 0.5f);
    }

    void FindPlayerNames()
    {
        LoopPlayerNames();

        if (PhotonNetwork.CurrentRoom.PlayerCount == 10)
        {
            pName1.gameObject.SetActive(true);
            pName2.gameObject.SetActive(true);
            pName3.gameObject.SetActive(true);
            pName4.gameObject.SetActive(true);
            pName5.gameObject.SetActive(true);
            pName6.gameObject.SetActive(true);
            pName7.gameObject.SetActive(true);
            pName8.gameObject.SetActive(true);
            pName9.gameObject.SetActive(true);
            pName10.gameObject.SetActive(true);
        }
        if (PhotonNetwork.CurrentRoom.PlayerCount == 9)
        {
            pName1.gameObject.SetActive(true);
            pName2.gameObject.SetActive(true);
            pName3.gameObject.SetActive(true);
            pName4.gameObject.SetActive(true);
            pName5.gameObject.SetActive(true);
            pName6.gameObject.SetActive(true);
            pName7.gameObject.SetActive(true);
            pName8.gameObject.SetActive(true);
            pName9.gameObject.SetActive(true);
            pName10.gameObject.SetActive(false);
        }
        if (PhotonNetwork.CurrentRoom.PlayerCount == 8)
        {
            pName1.gameObject.SetActive(true);
            pName2.gameObject.SetActive(true);
            pName3.gameObject.SetActive(true);
            pName4.gameObject.SetActive(true);
            pName5.gameObject.SetActive(true);
            pName6.gameObject.SetActive(true);
            pName7.gameObject.SetActive(true);
            pName8.gameObject.SetActive(true);
            pName9.gameObject.SetActive(false);
            pName10.gameObject.SetActive(false);
        }
        if (PhotonNetwork.CurrentRoom.PlayerCount == 7)
        {
            pName1.gameObject.SetActive(true);
            pName2.gameObject.SetActive(true);
            pName3.gameObject.SetActive(true);
            pName4.gameObject.SetActive(true);
            pName5.gameObject.SetActive(true);
            pName6.gameObject.SetActive(true);
            pName7.gameObject.SetActive(true);
            pName8.gameObject.SetActive(false);
            pName9.gameObject.SetActive(false);
            pName10.gameObject.SetActive(false);
        }
        if (PhotonNetwork.CurrentRoom.PlayerCount == 6)
        {
            pName1.gameObject.SetActive(true);
            pName2.gameObject.SetActive(true);
            pName3.gameObject.SetActive(true);
            pName4.gameObject.SetActive(true);
            pName5.gameObject.SetActive(true);
            pName6.gameObject.SetActive(true);
            pName7.gameObject.SetActive(false);
            pName8.gameObject.SetActive(false);
            pName9.gameObject.SetActive(false);
            pName10.gameObject.SetActive(false);
        }
        if (PhotonNetwork.CurrentRoom.PlayerCount == 5)
        {
            pName1.gameObject.SetActive(true);
            pName2.gameObject.SetActive(true);
            pName3.gameObject.SetActive(true);
            pName4.gameObject.SetActive(true);
            pName5.gameObject.SetActive(true);
            pName6.gameObject.SetActive(false);
            pName7.gameObject.SetActive(false);
            pName8.gameObject.SetActive(false);
            pName9.gameObject.SetActive(false);
            pName10.gameObject.SetActive(false);
        }
        if (PhotonNetwork.CurrentRoom.PlayerCount == 4)
        {
            pName1.gameObject.SetActive(true);
            pName2.gameObject.SetActive(true);
            pName3.gameObject.SetActive(true);
            pName4.gameObject.SetActive(true);
            pName5.gameObject.SetActive(false);
            pName6.gameObject.SetActive(false);
            pName7.gameObject.SetActive(false);
            pName8.gameObject.SetActive(false);
            pName9.gameObject.SetActive(false);
            pName10.gameObject.SetActive(false);
        }
        if (PhotonNetwork.CurrentRoom.PlayerCount == 3)
        {
            pName1.gameObject.SetActive(true);
            pName2.gameObject.SetActive(true);
            pName3.gameObject.SetActive(true);
            pName4.gameObject.SetActive(false);
            pName5.gameObject.SetActive(false);
            pName6.gameObject.SetActive(false);
            pName7.gameObject.SetActive(false);
            pName8.gameObject.SetActive(false);
            pName9.gameObject.SetActive(false);
            pName10.gameObject.SetActive(false);
        }
        if (PhotonNetwork.CurrentRoom.PlayerCount == 2)
        {
            pName1.gameObject.SetActive(true);
            pName2.gameObject.SetActive(true);
            pName3.gameObject.SetActive(false);
            pName4.gameObject.SetActive(false);
            pName5.gameObject.SetActive(false);
            pName6.gameObject.SetActive(false);
            pName7.gameObject.SetActive(false);
            pName8.gameObject.SetActive(false);
            pName9.gameObject.SetActive(false);
            pName10.gameObject.SetActive(false);
        }
        if (PhotonNetwork.CurrentRoom.PlayerCount == 1)
        {
            pName1.gameObject.SetActive(true);
            pName2.gameObject.SetActive(false);
            pName3.gameObject.SetActive(false);
            pName4.gameObject.SetActive(false);
            pName5.gameObject.SetActive(false);
            pName6.gameObject.SetActive(false);
            pName7.gameObject.SetActive(false);
            pName8.gameObject.SetActive(false);
            pName9.gameObject.SetActive(false);
            pName10.gameObject.SetActive(false);
        }

    }

    void LoopPlayerNames()
    {
        int i = 0;

        foreach (Player p in PhotonNetwork.PlayerList)
        {
            i++;
            //Debug.Log(p.NickName);//DELETE LATER
            //Debug.Log(PhotonNetwork.CurrentRoom.PlayerCount);
            //Debug.Log(p.CustomProperties.GetObjectData(info,context));

            if (pName1.isActiveAndEnabled && PhotonNetwork.CurrentRoom.PlayerCount == 1) { nText1.text = p.NickName; }
            if (pName2.isActiveAndEnabled && PhotonNetwork.CurrentRoom.PlayerCount == 2)
            {
                if (i == 1) { nText1.text = p.NickName; }
                if (i == 2) { nText2.text = p.NickName; }
            }
            if (pName3.isActiveAndEnabled && PhotonNetwork.CurrentRoom.PlayerCount == 3)
            {
                if (i == 1) { nText1.text = p.NickName; }
                if (i == 2) { nText2.text = p.NickName; }
                if (i == 3) { nText3.text = p.NickName; }
            }
            if (pName4.isActiveAndEnabled && PhotonNetwork.CurrentRoom.PlayerCount == 4)
            {
                if (i == 1) { nText1.text = p.NickName; }
                if (i == 2) { nText2.text = p.NickName; }
                if (i == 3) { nText3.text = p.NickName; }
                if (i == 4) { nText4.text = p.NickName; }
            }
            if (pName5.isActiveAndEnabled && PhotonNetwork.CurrentRoom.PlayerCount == 5)
            {
                if (i == 1) { nText1.text = p.NickName; }
                if (i == 2) { nText2.text = p.NickName; }
                if (i == 3) { nText3.text = p.NickName; }
                if (i == 4) { nText4.text = p.NickName; }
                if (i == 5) { nText5.text = p.NickName; }
            }
        }
    }

}
