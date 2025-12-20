using UnityEngine;
using Photon.Pun;

public class GameManager : MonoBehaviourPunCallbacks
{
    public PhotonView PlayerPrefab;
    
    public Transform spawnPlayerA;
    public Transform spawnPlayerB;

    public Transform[] spawnCubesA;
    public Transform[] spawnCubesB;

    void Start()
    {
        SpawnPlayer();

        if (PhotonNetwork.IsMasterClient)
            SpawnCubes();
    }

    void SpawnPlayer()
    {
        //int player = (int)PhotonNetwork.CurrentRoom.PlayerCount;
        //Vector3 pos = player == 1 ? spawnA.position : spawnB.position;

        //PhotonNetwork.Instantiate("Player", pos, Quaternion.identity);

        int actor = PhotonNetwork.LocalPlayer.ActorNumber;

        Vector3 pos = actor == 1
            ? spawnPlayerA.position
            : spawnPlayerB.position;
        
        PhotonNetwork.Instantiate(PlayerPrefab.name, pos, Quaternion.identity);        
    }

    void SpawnCubes()
    {
        foreach (var t in spawnCubesA)
            PhotonNetwork.Instantiate("CubeB", t.position, Quaternion.identity);

        foreach (var t in spawnCubesB)
            PhotonNetwork.Instantiate("CubeA", t.position, Quaternion.identity);
    }
}
