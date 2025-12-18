using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;

public class PhotonManager : MonoBehaviourPunCallbacks
{

    public TMP_Text connectionStatusText;
    public TMP_InputField nikeName;


    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        //ConnectToPhoton();
    }

    public void ConnectToPhoton()
    {
        if(nikeName.text != "")
        {
            PhotonNetwork.NickName = nikeName.text;
        }
        else
        {
            PhotonNetwork.NickName = "Player" + Random.Range(1000, 9999);
        }

        if (!PhotonNetwork.IsConnected)
        {
            PhotonNetwork.ConnectUsingSettings();
            connectionStatusText.text = "Conectando a Photon...";
        }
    }

    public override void OnConnectedToMaster()
    {
        connectionStatusText.text = "Conectado al Master Server";
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        connectionStatusText.text = "Entró al Lobby correctamente";

        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name != "Lobby")
        {
            PhotonNetwork.LoadLevel("Lobby");
        }
    }

    //#region Unirse Room
    //public override void OnJoinedRoom()
    //{
    //    Debug.Log("Entró a la sala: " + PhotonNetwork.CurrentRoom.Name);

    //    if (PhotonNetwork.IsMasterClient)
    //    {
    //        PhotonNetwork.LoadLevel("GameScene");
    //    }
    //}

    //#endregion

    public override void OnDisconnected(DisconnectCause cause)
    {
        base.OnDisconnected(cause);
    }

}
