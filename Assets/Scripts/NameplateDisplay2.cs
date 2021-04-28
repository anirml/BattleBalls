using TMPro;
using Photon.Pun;
using UnityEngine;

public class NameplateDisplay2 : MonoBehaviourPun
{
    [SerializeField] private TextMeshProUGUI nameText;

    private void Start() 
    {
        if (photonView.IsMine) {return;}    

        SetName();
    }

    private void SetName()
    {
        nameText.text = photonView.Owner.NickName;
    }
}
