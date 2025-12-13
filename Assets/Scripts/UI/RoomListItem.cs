using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RoomListItem : MonoBehaviour
{
    public Text roomNameText;
    RoomInfo roomInfo;

    public void Setup(RoomInfo info)
    {
        roomInfo = info;

        roomNameText.text = info.Name + " (" + info.PlayerCount + "/" + info.MaxPlayers + ")";
    }

    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(roomInfo.Name);
    }
}
