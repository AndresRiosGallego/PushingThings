using Photon.Pun;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviourPunCallbacks
{

    //public TMP_Text connectionStatusText;
    //public TMP_InputField nikeName;

    public void Login()
    {
        //if (nikeName.text != "")
        //{
        //    PhotonNetwork.NickName = nikeName.text;
        //}
        //else
        //{
        //    PhotonNetwork.NickName = "Player" + Random.Range(1000, 9999);
        //}

        //if (!PhotonNetwork.IsConnected)
        //{
        //    PhotonNetwork.ConnectUsingSettings();
        //    connectionStatusText.text = "Conectando a Photon...";
        //}
        
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        //connectionStatusText.text = "Conectado al Master Server";
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        //connectionStatusText.text = $"{PhotonNetwork.NickName} Entró al Lobby correctamente.";
        SceneManager.LoadScene("Lobby");
    }
}
