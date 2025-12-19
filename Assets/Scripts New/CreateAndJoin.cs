using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CreateAndJoin : MonoBehaviourPunCallbacks
{
    public InputField input_Create;
    public InputField input_Join;

    public void CreateRoom()
    {
        PhotonNetwork.CreateRoom(input_Create.text);
    }

    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(input_Join.text);
    }

    public void JoinRoomInList(string roomName)
    {
        PhotonNetwork.JoinRoom(roomName);
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Entraste a la sala correctamente");
        PhotonNetwork.LoadLevel("GameScene");
    }
}
