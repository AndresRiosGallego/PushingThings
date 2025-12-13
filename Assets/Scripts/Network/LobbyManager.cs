using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class LobbyManager : MonoBehaviourPunCallbacks
{
    public InputField roomNameInput;
    public Transform roomListContent;
    public GameObject roomListItemPrefab;
    public Text statusText;

    Dictionary<string, RoomInfo> cachedRooms = new Dictionary<string, RoomInfo>();

    void Start()
    {
        statusText.text = "En Lobby...";
    }


    #region Crear Room
    public void CreateRoom()
    {
        if (!PhotonNetwork.IsConnectedAndReady || !PhotonNetwork.InLobby)
        {
            Debug.LogWarning("No se puede crear sala: no está en Lobby");
            return;
        }

        string roomName = roomNameInput.text;

        if (string.IsNullOrEmpty(roomName))
            roomName = "Room_" + Random.Range(0, 1000);

        RoomOptions options = new RoomOptions
        {
            MaxPlayers = 2
        };

        PhotonNetwork.CreateRoom(roomName, options);
    }


    public override void OnCreatedRoom()
    {
        statusText.text = "Sala creada";
    }
    #endregion

    #region Unirse Room
    public override void OnJoinedRoom()
    {
        statusText.text = "Unido a sala";
        PhotonNetwork.LoadLevel("GameScene");
    }
    #endregion

    #region Lista de Rooms
    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        Debug.Log("Rooms recibidas: " + roomList.Count);

        foreach (RoomInfo room in roomList)
        {
            Debug.Log("Room: " + room.Name +
                      " Players: " + room.PlayerCount + "/" + room.MaxPlayers);

            if (room.RemovedFromList)
                cachedRooms.Remove(room.Name);
            else
                cachedRooms[room.Name] = room;
        }

        UpdateRoomListUI();
    }


    void UpdateRoomListUI()
    {
        foreach (Transform child in roomListContent)
        {
            Destroy(child.gameObject);
        }

        foreach (RoomInfo room in cachedRooms.Values)
        {
            GameObject item = Instantiate(roomListItemPrefab, roomListContent);
            item.GetComponent<RoomListItem>().Setup(room);
        }
    }
    #endregion
}
