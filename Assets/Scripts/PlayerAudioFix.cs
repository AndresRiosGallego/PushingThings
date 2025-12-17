using Photon.Pun;
using UnityEngine;

public class PlayerAudioFix : MonoBehaviourPun
{
    void Start()
    {
        if (!photonView.IsMine)
        {
            GetComponent<AudioListener>().enabled = false;
        }
    }
}
