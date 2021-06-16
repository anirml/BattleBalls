using TMPro;
using Photon.Pun;
using UnityEngine;

public class NameplateDisplay : MonoBehaviourPun
{
    [SerializeField] private TextMeshProUGUI nameText;

    Quaternion rotation;
    private void Start()
    {
        SetName();
    }

    void Awake()
    {
        rotation = transform.rotation;
    }

    void FixedUpdate()
    {
        transform.rotation = rotation;
    }
    private void SetName()
    {
        nameText.text = photonView.Owner.NickName;
    }
}
