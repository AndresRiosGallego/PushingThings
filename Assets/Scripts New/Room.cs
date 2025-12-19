using UnityEngine;
using TMPro;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class Room : MonoBehaviour
{
    public Text Name;
    public void JoinRoom()
    {
        GameObject.Find("CreateAndJoin").GetComponent<CreateAndJoin>().JoinRoomInList(Name.text);
        //GameObject.Find("RoomListItem").GetComponent<CreateAndJoin>().JoinRoomInList(Name.text);
    }
}
