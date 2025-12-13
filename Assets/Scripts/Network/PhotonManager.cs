using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class PhotonManager : MonoBehaviourPunCallbacks
{
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
        if (!PhotonNetwork.IsConnected)
        {
            PhotonNetwork.ConnectUsingSettings();
            Debug.Log("Conectando a Photon...");
        }
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Conectado al Master Server");
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        Debug.Log("Entró al Lobby correctamente");

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

}
