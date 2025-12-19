using UnityEngine;
using Photon.Pun;

public class SpawnManager : MonoBehaviourPunCallbacks
{

    public PhotonView playerPrefab;
    public Transform spawnPoints;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PhotonNetwork.Instantiate(playerPrefab.name, spawnPoints.position, spawnPoints.rotation);
    }
}
