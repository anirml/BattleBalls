using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;
using UnityEngine.UI;
using TMPro;

public class ScoreHandler : MonoBehaviour
{
    GameObject[] playersArray;
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
            nText4.text = "";
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
            nText3.text = "";
            pName4.gameObject.SetActive(false);
            nText4.text = "";
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
            nText2.text = "";
            pName3.gameObject.SetActive(false);
            nText3.text = "";
            pName4.gameObject.SetActive(false);
            nText4.text = "";
            pName5.gameObject.SetActive(false);
            pName6.gameObject.SetActive(false);
            pName7.gameObject.SetActive(false);
            pName8.gameObject.SetActive(false);
            pName9.gameObject.SetActive(false);
            pName10.gameObject.SetActive(false);
        }

        LoopPlayerNames();
    }

    void LoopPlayerNames()
    {
        int i = 0;

        float pScale;
        Color32 pColor;

        GameObject namePlateText;

        List<float> pScaleList = new List<float>();
        List<Color32> pColorList = new List<Color32>();
        List<string> pNames = new List<string>();
        playersArray = GameObject.FindGameObjectsWithTag("Player");

        // if (playersArray == null) { return; }

        foreach (GameObject plr in playersArray)
        {
            i++;

            pScale = plr.GetComponent<Transform>().lossyScale.x;
            pColor = plr.GetComponent<MeshRenderer>().material.color;

            namePlateText = plr.transform.GetChild(0).GetChild(1).GetChild(0).gameObject;
            Text namePlayerText = namePlateText.GetComponent<Text>();

            //Sets transparency, value 255 is no transparency
            pColor.a = (byte)100;

            pScaleList.Add(pScale * 100);
            pColorList.Add(pColor);
            pNames.Add(namePlayerText.text);

            //Debug.Log(namePlayerText.text);


            if (PhotonNetwork.CurrentRoom.PlayerCount == 1) { nText1.text = pScaleList[0].ToString("F0") + "  " + pNames[0]; pName1.color = pColorList[0]; }

            if (PhotonNetwork.CurrentRoom.PlayerCount == 2)
            {
                if (i == 1) { nText1.text = pScaleList[0].ToString("F0") + "  " + pNames[0]; pName1.color = pColorList[0]; }
                if (i == 2) { nText2.text = pScaleList[1].ToString("F0") + "  " + pNames[1]; pName2.color = pColorList[1]; }
            }
            if (PhotonNetwork.CurrentRoom.PlayerCount == 3)
            {
                if (i == 1) { nText1.text = pScaleList[0].ToString("F0") + "  " + pNames[0]; pName1.color = pColorList[0]; }
                if (i == 2) { nText2.text = pScaleList[1].ToString("F0") + "  " + pNames[1]; pName2.color = pColorList[1]; }
                if (i == 3) { nText3.text = pScaleList[2].ToString("F0") + "  " + pNames[2]; pName3.color = pColorList[0]; }
            }
            if (PhotonNetwork.CurrentRoom.PlayerCount == 4)
            {
                if (i == 1) { nText1.text = pScaleList[0].ToString("F0") + "  " + pNames[0]; pName1.color = pColorList[0]; }
                if (i == 2) { nText2.text = pScaleList[1].ToString("F0") + "  " + pNames[1]; pName2.color = pColorList[1]; }
                if (i == 3) { nText3.text = pScaleList[2].ToString("F0") + "  " + pNames[2]; pName3.color = pColorList[2]; }
                if (i == 4) { nText4.text = pScaleList[3].ToString("F0") + "  " + pNames[3]; pName4.color = pColorList[3]; }
            }
            if (PhotonNetwork.CurrentRoom.PlayerCount == 5)
            {
                if (i == 1) { nText1.text = pScaleList[0].ToString("F0") + "  " + pNames[0]; pName1.color = pColorList[0]; }
                if (i == 2) { nText2.text = pScaleList[1].ToString("F0") + "  " + pNames[1]; pName2.color = pColorList[1]; }
                if (i == 3) { nText3.text = pScaleList[2].ToString("F0") + "  " + pNames[2]; pName3.color = pColorList[2]; }
                if (i == 4) { nText4.text = pScaleList[3].ToString("F0") + "  " + pNames[3]; pName4.color = pColorList[3]; }
                if (i == 5) { nText5.text = pScaleList[4].ToString("F0") + "  " + pNames[4]; pName5.color = pColorList[4]; }

            }
            if (PhotonNetwork.CurrentRoom.PlayerCount == 6)
            {
                if (i == 1) { nText1.text = pScaleList[0].ToString("F0") + "  " + pNames[0]; pName1.color = pColorList[0]; }
                if (i == 2) { nText2.text = pScaleList[1].ToString("F0") + "  " + pNames[1]; pName2.color = pColorList[1]; }
                if (i == 3) { nText3.text = pScaleList[2].ToString("F0") + "  " + pNames[2]; pName3.color = pColorList[2]; }
                if (i == 4) { nText4.text = pScaleList[3].ToString("F0") + "  " + pNames[3]; pName4.color = pColorList[3]; }
                if (i == 5) { nText5.text = pScaleList[4].ToString("F0") + "  " + pNames[4]; pName5.color = pColorList[4]; }
                if (i == 6) { nText6.text = pScaleList[5].ToString("F0") + "  " + pNames[5]; pName6.color = pColorList[5]; }
            }
            if (PhotonNetwork.CurrentRoom.PlayerCount == 7)
            {
                if (i == 1) { nText1.text = pScaleList[0].ToString("F0") + "  " + pNames[0]; pName1.color = pColorList[0]; }
                if (i == 2) { nText2.text = pScaleList[1].ToString("F0") + "  " + pNames[1]; pName2.color = pColorList[1]; }
                if (i == 3) { nText3.text = pScaleList[2].ToString("F0") + "  " + pNames[2]; pName3.color = pColorList[2]; }
                if (i == 4) { nText4.text = pScaleList[3].ToString("F0") + "  " + pNames[3]; pName4.color = pColorList[3]; }
                if (i == 5) { nText5.text = pScaleList[4].ToString("F0") + "  " + pNames[4]; pName5.color = pColorList[4]; }
                if (i == 6) { nText6.text = pScaleList[5].ToString("F0") + "  " + pNames[5]; pName6.color = pColorList[5]; }
                if (i == 7) { nText7.text = pScaleList[6].ToString("F0") + "  " + pNames[6]; pName7.color = pColorList[6]; }

            }
            if (PhotonNetwork.CurrentRoom.PlayerCount == 8)
            {
                if (i == 1) { nText1.text = pScaleList[0].ToString("F0") + "  " + pNames[0]; pName1.color = pColorList[0]; }
                if (i == 2) { nText2.text = pScaleList[1].ToString("F0") + "  " + pNames[1]; pName2.color = pColorList[1]; }
                if (i == 3) { nText3.text = pScaleList[2].ToString("F0") + "  " + pNames[2]; pName3.color = pColorList[2]; }
                if (i == 4) { nText4.text = pScaleList[3].ToString("F0") + "  " + pNames[3]; pName4.color = pColorList[3]; }
                if (i == 5) { nText5.text = pScaleList[4].ToString("F0") + "  " + pNames[4]; pName5.color = pColorList[4]; }
                if (i == 6) { nText6.text = pScaleList[5].ToString("F0") + "  " + pNames[5]; pName6.color = pColorList[5]; }
                if (i == 7) { nText7.text = pScaleList[6].ToString("F0") + "  " + pNames[6]; pName7.color = pColorList[6]; }
                if (i == 8) { nText8.text = pScaleList[7].ToString("F0") + "  " + pNames[7]; pName8.color = pColorList[7]; }
            }
            if (PhotonNetwork.CurrentRoom.PlayerCount == 9)
            {
                if (i == 1) { nText1.text = pScaleList[0].ToString("F0") + "  " + pNames[0]; pName1.color = pColorList[0]; }
                if (i == 2) { nText2.text = pScaleList[1].ToString("F0") + "  " + pNames[1]; pName2.color = pColorList[1]; }
                if (i == 3) { nText3.text = pScaleList[2].ToString("F0") + "  " + pNames[2]; pName3.color = pColorList[2]; }
                if (i == 4) { nText4.text = pScaleList[3].ToString("F0") + "  " + pNames[3]; pName4.color = pColorList[3]; }
                if (i == 5) { nText5.text = pScaleList[4].ToString("F0") + "  " + pNames[4]; pName5.color = pColorList[4]; }
                if (i == 6) { nText6.text = pScaleList[5].ToString("F0") + "  " + pNames[5]; pName6.color = pColorList[5]; }
                if (i == 7) { nText7.text = pScaleList[6].ToString("F0") + "  " + pNames[6]; pName7.color = pColorList[6]; }
                if (i == 8) { nText8.text = pScaleList[7].ToString("F0") + "  " + pNames[7]; pName8.color = pColorList[7]; }
                if (i == 9) { nText9.text = pScaleList[8].ToString("F0") + "  " + pNames[8]; pName9.color = pColorList[8]; }
            }
            if (PhotonNetwork.CurrentRoom.PlayerCount == 10)
            {
                if (i == 1) { nText1.text = pScaleList[0].ToString("F0") + "  " + pNames[0]; pName1.color = pColorList[0]; }
                if (i == 2) { nText2.text = pScaleList[1].ToString("F0") + "  " + pNames[1]; pName2.color = pColorList[1]; }
                if (i == 3) { nText3.text = pScaleList[2].ToString("F0") + "  " + pNames[2]; pName3.color = pColorList[2]; }
                if (i == 4) { nText4.text = pScaleList[3].ToString("F0") + "  " + pNames[3]; pName4.color = pColorList[3]; }
                if (i == 5) { nText5.text = pScaleList[4].ToString("F0") + "  " + pNames[4]; pName5.color = pColorList[4]; }
                if (i == 6) { nText6.text = pScaleList[5].ToString("F0") + "  " + pNames[5]; pName6.color = pColorList[5]; }
                if (i == 7) { nText7.text = pScaleList[6].ToString("F0") + "  " + pNames[6]; pName7.color = pColorList[6]; }
                if (i == 8) { nText8.text = pScaleList[7].ToString("F0") + "  " + pNames[7]; pName8.color = pColorList[7]; }
                if (i == 9) { nText9.text = pScaleList[8].ToString("F0") + "  " + pNames[8]; pName9.color = pColorList[8]; }
                if (i == 10) { nText10.text = pScaleList[9].ToString("F0") + "  " + pNames[9]; pName10.color = pColorList[9]; }
            }

        }

        pScaleList = null;

        pColorList = null;

        playersArray = null;

        pNames = null;
    }

}
