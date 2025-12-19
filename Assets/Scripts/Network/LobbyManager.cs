using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LobbyManager : MonoBehaviourPunCallbacks
{
    public InputField roomNameInput;
    public Transform roomListContent;
    public GameObject roomListItemPrefab;
    public Text statusText;    

    Dictionary<string, RoomInfo> cachedRooms = new Dictionary<string, RoomInfo>();

    void Start()
    {
        statusText.text = $"En Lobby... {PhotonNetwork.NickName}" ;        
    }
    

    #region Crear Room
    public void CreateRoom()
    {
        if (!PhotonNetwork.IsConnectedAndReady || !PhotonNetwork.InLobby)
        {
            Debug.LogWarning("No se puede crear sala: no está en Lobby");
            return;
        }

        if (string.IsNullOrEmpty(roomNameInput.text))
        {
            statusText.text = "El nombre de la sala no puede estar vacío";
            return;
        }

        string roomName = roomNameInput.text;

        if (string.IsNullOrEmpty(roomName))
            roomName = "Room_" + UnityEngine.Random.Range(0, 1000);

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

    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(roomNameInput.text);
    }

    public override void OnJoinedRoom()
    {
        statusText.text = "Unido a sala";
        if (PhotonNetwork.IsMasterClient)
            PhotonNetwork.LoadLevel("GameScene");
    }

    #endregion

    #region Lista de Rooms
    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        foreach (RoomInfo room in roomList)
        {
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
