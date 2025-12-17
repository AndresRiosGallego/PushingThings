using Photon.Pun;
using UnityEngine;

public class PlayerCameraSetup : MonoBehaviourPun
{
    void Start()
    {
        if (!photonView.IsMine)
        {
            GetComponentInChildren<Camera>().enabled = false;
            GetComponentInChildren<AudioListener>().enabled = false;
        }
    }
}
