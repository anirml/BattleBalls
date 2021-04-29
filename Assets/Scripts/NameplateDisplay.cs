using TMPro;
using Photon.Pun;
using UnityEngine;

public class NameplateDisplay : MonoBehaviourPun
{
    [SerializeField] private TextMeshProUGUI nameText;

    private void Start() 
    {
        // Uncomment line below for photon implementation
        // if (photonView.IsMine) {return;}    

        SetName();
    }

    private void SetName()
    {
        nameText.text = photonView.Owner.NickName;
    }
}
