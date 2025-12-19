using UnityEngine;
using Photon.Pun;
using TMPro;

public class PlayerHealth : MonoBehaviourPun, IPunObservable
{
    public float health = 100f;

    // UI global en la escena
    public TextMeshProUGUI textoJugadorLocal;
    public TextMeshProUGUI textoOtroJugador;

    void Start()
    {
        if (textoJugadorLocal == null)
            textoJugadorLocal = GameObject.Find("Text").GetComponent<TextMeshProUGUI>();

        if (textoOtroJugador == null)
            textoOtroJugador = GameObject.Find("Text1").GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        if (photonView.IsMine)
        {
            if (Input.GetKeyDown(KeyCode.H))
            {
                health -= 10f;
            }

            if (textoJugadorLocal != null)
                textoJugadorLocal.text = health.ToString();
        }
        else
        {
            if (textoOtroJugador != null)
                textoOtroJugador.text = health.ToString();
        }
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(health);
        }
        else
        {
            health = (float)stream.ReceiveNext();
        }
    }
}
