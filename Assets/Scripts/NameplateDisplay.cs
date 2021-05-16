using TMPro;
using Photon.Pun;
using UnityEngine;

public class NameplateDisplay : MonoBehaviourPun
{
    [SerializeField] private TextMeshProUGUI nameText;

    private void Start() 
    {
        SetName();
    }

    private void SetName()
    {
        nameText.text = photonView.Owner.NickName;
    }
}
