using Photon.Pun;
using System;
using UnityEngine;

public class PlayerController : MonoBehaviourPunCallbacks
{
    public float speed = 5f;

    [Header("Materials")]
    public Material playerAMaterial;
    public Material playerBMaterial;

    [SerializeField] private Renderer bodyRenderer;
    [SerializeField] private Transform cameraHolder;
    [SerializeField] private float cameraFix;

    void Start()
    {
        ApplyMaterialIfReady();
        ConfigurarCamara();
    }

    private void ConfigurarCamara()
    {
        if(photonView.Owner.ActorNumber ==1)
            cameraHolder.localPosition += new Vector3(cameraFix, 0f, 0f);
        else
            cameraHolder.localPosition -= new Vector3(cameraFix, 0f, 0f);
    }

    void ApplyMaterialIfReady()
    {
        //if (!photonView.IsMine) return;

        //int player = (int)PhotonNetwork.CurrentRoom.PlayerCount;
        //bodyRenderer.material = player == 1 ? playerAMaterial : playerBMaterial;

        int actor = photonView.Owner.ActorNumber;
        bodyRenderer.material = actor == 1 ? playerAMaterial : playerBMaterial;
    }

    void Update()
    {
        if (photonView.IsMine)
        {
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");

            Vector3 move = new Vector3(h, 0, v);
            transform.Translate(move * speed * Time.deltaTime);
        }
    }
}
