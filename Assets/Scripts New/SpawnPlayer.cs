using UnityEngine;
using Photon.Pun;
using TMPro;
public class SpawnPlayer : MonoBehaviourPunCallbacks
{

    public PhotonView playerPrefab;
    public Transform[] spawnPosition;
    public TextMeshProUGUI texto;
    public int playerIndex;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerIndex = PhotonNetwork.CurrentRoom.PlayerCount;
        PhotonNetwork.Instantiate(playerPrefab.name, spawnPosition[playerIndex-1].position, spawnPosition[playerIndex-1].rotation);
        texto.text = playerIndex.ToString();
    }
}
