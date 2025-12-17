using Photon.Pun;
using UnityEngine;

public class PlayerController : MonoBehaviourPunCallbacks
{
    public float speed = 5f;

    [Header("Materials")]
    public Material playerAMaterial;
    public Material playerBMaterial;

    public Renderer bodyRenderer;

    void Start()
    {
        ApplyMaterialIfReady();
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
